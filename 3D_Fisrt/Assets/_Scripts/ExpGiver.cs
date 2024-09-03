using UnityEngine;

public class ExpGiver : MonoBehaviour
{
    public int experienceAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // L?y component LevelSystem t? Player
            LevelSystem levelSystem = other.GetComponent<LevelSystem>();
            if (levelSystem != null)
            {
                levelSystem.AddExperience(experienceAmount);
                Debug.Log("Player gained " + experienceAmount + " EXP!");
                Destroy(gameObject);
            }
        }
    }
}
