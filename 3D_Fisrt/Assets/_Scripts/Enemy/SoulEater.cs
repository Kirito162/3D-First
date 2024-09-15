using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SoulEater : Enemy
{
    [SerializeField] float shootSpeed = 5f;
    [SerializeField] Transform fireballSpawnPoint;
    public EnemyDetection enemyDetection;
    private void Start()
    {
        enemyDetection = GetComponent<EnemyDetection>();
        
    }
    public void Shoot()
    {
        Transform target = enemyDetection.GetClosestEnemy();
        objAttack[0].transform.position = fireballSpawnPoint.position;
        objAttack[0].transform.rotation = fireballSpawnPoint.rotation;
        Vector3 direction = (target.position - fireballSpawnPoint.position).normalized;
        objAttack[0].transform.SetParent(null);

        SetDamage(objAttack[0]);
        objAttack[0].SetActive(true);
        objAttack[0].GetComponent<Rigidbody>().velocity = direction * shootSpeed;
        //objAttack[0].GetComponent<Rigidbody>().velocity = fireballSpawnPoint.forward * shootSpeed;

        StartCoroutine(DeactiveObjAttack(1f, objAttack[0]));
    }
}
