using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health, IDamageable
{
    private PlayerController controller;
    public PlayerData playerData;
    //public UnityEvent onPlayerDeath;
    public bool isShield = false;
    // Start is called before the first frame update
    public override void OnEnable() 
    {
        //load state da save
        playerData.hp = PlayerPrefs.GetInt("HP", 100);
        playerData.damage = PlayerPrefs.GetInt("Damage", 10);
        playerData.mana = PlayerPrefs.GetInt("Mana", 50);
        hp = playerData.hp;
        base.OnEnable();
        //transform.position = playerData.currentPosition;
        controller = GetComponent<PlayerController>();

    }

    public override void TakeDamage(int damageAmount, bool isSkillDamage = false)
    {
        if (isShield) { return; }
        base.TakeDamage(damageAmount, isSkillDamage);
        if (hp <=0) 
        { 
            controller.enabled = false; 
        }
        Singleton.Instance.DamagePopUpGenerator.CreatePopup(transform.position + new Vector3(0, 1, 0), damageAmount.ToString(), Color.yellow);
    }

}
