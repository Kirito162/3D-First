using UnityEngine;

public class Item : MonoBehaviour
{
    public int experienceAmount = 50;
    public int hpAmount = 0;
    public int manaAmount = 0;
    public int goldAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // L?y component LevelSystem t? Player
            Singleton.Instance.AudioManager.PlayAtPointSFX(14, transform);
            LevelSystem levelSystem = other.GetComponent<LevelSystem>();
            if (levelSystem != null)
            {
                levelSystem.AddExperience(experienceAmount);
                Debug.Log("Player gained " + experienceAmount + " EXP!");
            }
            Health health = other.GetComponentInParent<Health>();
            if(health != null)
            {
                health.Heal(hpAmount);
            }
            PlayerMana playerMana = other.GetComponent<PlayerMana>();
            if (playerMana != null)
            {
                playerMana.TakeMana(-manaAmount);
            }
            GoldManager goldManager = other.GetComponent<GoldManager>();
            if (goldManager != null)
            {
                int gold = Random.Range(goldAmount - 10, goldAmount + 10);
                goldManager.AddGold(gold);
            }
            Destroy(gameObject);
        }
        /*else if (other.CompareTag("Enemy"))
        {
            
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(-hpAmount);
            }
            Destroy(gameObject);
        }*/
    }
}
