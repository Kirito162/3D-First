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
        hp = playerData.hp;
        base.OnEnable();
        //transform.position = playerData.currentPosition;
        controller = GetComponent<PlayerController>();

    }

    public override void TakeDamage(int damageAmount)
    {
        if (isShield) { return; }
        base.TakeDamage(damageAmount);
        if (hp <=0) 
        { 
            controller.enabled = false; 
        }
    }

}
