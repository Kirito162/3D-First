using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
    ParticleSystem ps;
    public int damage = 10;
    public DealDamage dealdamage;
    private void Start()
    {
        damage = dealdamage.baseDamage + dealdamage.damageBonus;
    }
    void OnEnable()
    {
        
        ps = GetComponent<ParticleSystem>();

        AddDragonCollidersToTrigger();
    }

    void AddDragonCollidersToTrigger()
    {
        var trigger = ps.trigger;
        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < dragons.Length; i++)
        {
            Collider dragonCollider = dragons[i].GetComponent<Collider>();
            if (dragonCollider != null)
            {
                trigger.SetCollider(i, dragonCollider);
            }
        }
    }

    void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        ParticleSystem.ColliderData insideData;
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out insideData);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        for (int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];

            for (int j = 0; j < insideData.GetColliderCount(i); j++)
            {
                Collider collider = (Collider)insideData.GetCollider(i, j);
                if (collider != null && collider.CompareTag("Enemy"))
                {
                    IDamageable damageable = collider.GetComponentInParent<IDamageable>();
                    damageable?.TakeDamage(damage);
                }
            }

            inside[i] = p;
            Destroy(gameObject);
        }

        

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}

