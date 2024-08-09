using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    //public EnemyData state;
    public int hp;
    public Animator animator;
    public Collider colliders;
    public Slider healthBar;
    public TextMeshProUGUI textHp;
    public int damage;

    public virtual void OnEnable()
    {
        ChangeHealthBar();
    }
    public virtual void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            hp = 0;
            animator.SetTrigger("die");
            colliders.enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
        ChangeHealthBar();
    }

    public virtual void ChangeHealthBar()
    {
        healthBar.value = hp;
        textHp.text = hp + "/" + healthBar.maxValue;
    }

}
