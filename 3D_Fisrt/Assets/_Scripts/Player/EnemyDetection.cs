using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRadius = 10f;
    public LayerMask targetLayer;
    public Camera playerCamera;

    //public List<Transform> wayPoints = new List<Transform>();

    private void Start()
    {
        //playerCamera = FindAnyObjectByType<Camera>();
        playerCamera = FindObjectOfType<Camera>();
        /*GameObject go = GameObject.FindGameObjectWithTag("WayPoints");

        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }*/
    }
    
    public List<Transform> GetEnemiesInRange()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
        List<Transform> enemyTransforms = new List<Transform>();

        foreach (var enemy in enemies)
        {
            if (enemy.transform != transform)
            {
                enemyTransforms.Add(enemy.transform);
            }
        }

        return enemyTransforms;
    }

    // Find Enemy closest in view camera (for player)
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
    // Find Enemy closest
    public Transform GetClosestEnemy()
    {
        List<Transform> enemies = GetEnemiesInRange();
        Transform closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}

