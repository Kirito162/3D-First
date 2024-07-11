using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerScript : MonoBehaviour
{
    ParticleSystem ps;
    public int damage = 10; // S? l??ng s�t th??ng g�y ra

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Congratulation");
        Debug.Log(other.name);
        // Ki?m tra xem ??i t??ng va ch?m c� tag "Dragon" hay kh�ng
        if (other.CompareTag("Dragon"))
        {
            Dragon dragon = other.GetComponent<Dragon>();
            if (dragon != null)
            {
                dragon.TakeDamage(damage);
            }
        }
    }
 
}

