using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject hitAttack;
    public Transform hitPos;
    public EnemyDetection detection;
    public StateSO state;
    private void Start()
    {
        detection = GetComponent<EnemyDetection>();
    }
    public void Update()
    {
        Transform target = detection.GetClosestEnemy();
        if(target != null) 
        {
            transform.LookAt(target.position);
        }
    }
    public void Attack()
    {
        GameObject bullet = Instantiate(hitAttack, hitPos.position, transform.rotation);
        DealDamage dealdamageScript = bullet.GetComponent<DealDamage>();
        if (dealdamageScript != null)
        {
            dealdamageScript.baseDamage = state.damage;
        }
    }
}
