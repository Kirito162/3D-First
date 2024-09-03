using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
    ParticleSystem ps;
    public int damage = 10;
    public DealDamage dealDamage;
    private void Start()
    {
        damage = dealDamage.baseDamage + dealDamage.damageBonus;
    }
    void OnEnable()
    {
        
        ps = GetComponent<ParticleSystem>();

        AddCollidersToTrigger();
    }

    void AddCollidersToTrigger()
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
        ParticleSystem.ColliderData insideData;
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside, out insideData);

        for (int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];

            for (int j = 0; j < insideData.GetColliderCount(i); j++)
            {
                Collider collider = (Collider)insideData.GetCollider(i, j);
                if (collider != null && collider.CompareTag("Enemy"))
                {
                    ProcessCollision(collider);
                }
            }

            inside[i] = p;
            //Destroy(gameObject);
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
    }
    void ProcessCollision(Collider other)
    {
        if (((1 << other.gameObject.layer) & dealDamage.layerExcept) == 0)
        {
            IDamageable damageable = other.GetComponentInParent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
    }
    }

