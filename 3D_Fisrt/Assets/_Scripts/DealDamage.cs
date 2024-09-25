using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int baseDamage = 0;
    public int damageBonus = 0;
    public LayerMask layerExcept;
    [SerializeField] private bool isFalseAfterDeal = false;
    [SerializeField] private bool isSkillDamage = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        /*        if (other.gameObject.TryGetComponent(out IDamageable idamageable))
                {
                    idamageable.Damage(damage);
                }*/
        if (((1 << other.gameObject.layer) & layerExcept) == 0)
        {
            
            IDamageable damageable = other.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(baseDamage + damageBonus, isSkillDamage);
            }
            else
            {
                IDamageable damageablePlayer = other.GetComponent<IDamageable>();
                damageablePlayer?.TakeDamage(baseDamage + damageBonus, isSkillDamage);
            }

            if (isFalseAfterDeal)
            {
                gameObject.SetActive(false);
            }
        }
        


    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
