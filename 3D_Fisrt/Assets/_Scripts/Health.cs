using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    //public EnemyData state;
    public int hp;
    public Animator animator;
    public Collider colliders;
    public Slider healthBar;
    public TextMeshProUGUI textHp;
    //public int damage;
    public UnityEvent onDeath;
    public GameObject healEffect;
    public float getHitChance = 0.5f; // xac suat chay anim getHit

    public virtual void OnEnable()
    {
        healthBar.maxValue = hp;
        ChangeHealthBar();
        InvokeRepeating("RestHP", 10, 10);
    }
    public virtual void TakeDamage(int damageAmount, bool isSkillDamage = false)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            hp = 0;
            ChangeHealthBar();
            animator.SetTrigger("die");
            colliders.enabled = false;
            CancelInvoke("RestHP");
            onDeath?.Invoke();
        }
        else
        {
            // neu la skill dac biet gay damage thi se chac chan goi anim getHit(nhu bi lam choang)
            if (isSkillDamage)
            {
                animator.SetTrigger("damage");
            }
            else if (Random.value < getHitChance)
            {
                animator.SetTrigger("damage");
            }
            ChangeHealthBar();
        }
    }
    public virtual void Heal(int healAmount)
    {
        hp += healAmount;
        if (hp > healthBar.maxValue)
        {
            hp = (int)healthBar.maxValue;
        }
        ChangeHealthBar();
        if (healAmount > 0)
        {
            healEffect.SetActive(false);
            healEffect.SetActive(true);
        }
    }

    public virtual void ChangeHealthBar()
    {
        healthBar.value = hp;
        textHp.text = hp + "/" + healthBar.maxValue;
    }
    public virtual void RestHP()
    {
        hp += Mathf.RoundToInt(healthBar.maxValue / 20f);
        if (hp > (int)healthBar.maxValue)
        {
            hp = (int)healthBar.maxValue;
        }
        ChangeHealthBar();
    }
}
