using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
    ParticleSystem ps;
    public int damage = 10; // S? l??ng sát th??ng gây ra

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();

        // Thi?t l?p TriggerModule
        var trigger = ps.trigger;
        trigger.enabled = true;
        trigger.inside = ParticleSystemOverlapAction.Callback;
        trigger.enter = ParticleSystemOverlapAction.Callback;
        trigger.exit = ParticleSystemOverlapAction.Callback;

        // T? ??ng thêm colliders c?a ??i t??ng "Dragon"
        AddDragonCollidersToTrigger();
    }

    void AddDragonCollidersToTrigger()
    {
        var trigger = ps.trigger;
        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");
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

        // Duy?t qua các h?t bên trong trigger
        for (int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];

            // Duy?t qua các collider liên quan ??n h?t
            for (int j = 0; j < insideData.GetColliderCount(i); j++)
            {
                Collider collider = (Collider)insideData.GetCollider(i, j);
                if (collider != null && collider.CompareTag("Dragon"))
                {
                    // X? lý logic khi va ch?m v?i collider c?a "Dragon"
                    Dragon dragon = collider.GetComponentInParent<Dragon>();
                    if (dragon != null)
                    {
                        dragon.TakeDamage(damage);
                    }
                }
            }

            inside[i] = p;
            Destroy(gameObject);
        }

        

        // C?p nh?t l?i các h?t trong Particle System
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}

