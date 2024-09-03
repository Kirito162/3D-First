using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int baseDamage = 0;
    public int damageBonus = 0;
    public LayerMask layerExcept;
    [SerializeField] private bool isFalseAfterDeal = true;
    [SerializeField] private bool isDestroyAfterDeal = true;

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
                damageable.TakeDamage(baseDamage + damageBonus);
            }
            else
            {
                IDamageable damageablePlayer = other.GetComponent<IDamageable>();
                damageablePlayer?.TakeDamage(baseDamage + damageBonus);

                
            }
        }
        if (isDestroyAfterDeal) 
        {
            Destroy(gameObject, 0.5f);
        }
        if (isDestroyAfterDeal)
        {
            gameObject.SetActive(false);
        }


    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
