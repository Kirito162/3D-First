using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRadius = 10f;
    public LayerMask enemyLayer;
    public Camera playerCamera;
    public List<Transform> GetEnemiesInRange()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
        List<Transform> enemyTransforms = new List<Transform>();

        foreach (var enemy in enemies)
        {
            enemyTransforms.Add(enemy.transform);
        }

        return enemyTransforms;
    }

    
    public Transform GetClosestEnemyInView()
    {
        List<Transform> enemies = GetEnemiesInRange();
        Transform closestEnemy = null;
        float closestAngle = float.MaxValue;

        foreach (var enemy in enemies)
        {
            Vector3 directionToEnemy = (enemy.position - playerCamera.transform.position).normalized;
            float angle = Vector3.Angle(playerCamera.transform.forward, directionToEnemy);

            if (angle < closestAngle)
            {
                closestAngle = angle;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}

