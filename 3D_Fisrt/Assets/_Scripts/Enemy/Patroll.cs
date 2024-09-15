using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroll : StateMachineBehaviour
{
    float timer;
    [SerializeField] float timePatrol = 10f;
    [SerializeField] float radiusWaypoints = 10f;
    //List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent navMeshAgent;
    public float chaseRange = 8;
    public EnemyDetection enemyDetection;
    public List<Vector3> wayPoints = new List<Vector3>();

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetWaypointsAroundEnemy(animator.transform.position, radiusWaypoints);
        timer = 0;
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        enemyDetection = animator.GetComponent<EnemyDetection>();
        /*GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }*/
        navMeshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)]);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            GetWaypointsAroundEnemy(animator.transform.position, radiusWaypoints);
            navMeshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)]);
        }
        timer += Time.deltaTime;
        if (timer > timePatrol)
        {
            animator.SetBool("isPatrolling", false);
        }
        Transform target = enemyDetection.GetClosestEnemy();
        if (target != null) 
        {
            float distance = Vector3.Distance(target.position, animator.transform.position);
            if (distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.SetDestination(navMeshAgent.transform.position);
    }


    private void GetWaypointsAroundEnemy(Vector3 enemyPosition, float radius)
    {
        wayPoints.Clear();
        // T?o 8 ?i?m xung quanh v? tr� hi?n t?i c?a enemy v?i kho?ng c�ch radius
        wayPoints.Add(enemyPosition + new Vector3(0, 0, radius)); // B?c
        wayPoints.Add(enemyPosition + new Vector3(radius * Mathf.Cos(45 * Mathf.Deg2Rad), 0, radius * Mathf.Sin(45 * Mathf.Deg2Rad))); // ?�ng B?c
        wayPoints.Add(enemyPosition + new Vector3(radius, 0, 0)); // ?�ng
        wayPoints.Add(enemyPosition + new Vector3(radius * Mathf.Cos(45 * Mathf.Deg2Rad), 0, -radius * Mathf.Sin(45 * Mathf.Deg2Rad))); // ?�ng Nam
        wayPoints.Add(enemyPosition + new Vector3(0, 0, -radius)); // Nam
        wayPoints.Add(enemyPosition + new Vector3(-radius * Mathf.Cos(45 * Mathf.Deg2Rad), 0, -radius * Mathf.Sin(45 * Mathf.Deg2Rad))); // T�y Nam
        wayPoints.Add(enemyPosition + new Vector3(-radius, 0, 0)); // T�y
        wayPoints.Add(enemyPosition + new Vector3(-radius * Mathf.Cos(45 * Mathf.Deg2Rad), 0, radius * Mathf.Sin(45 * Mathf.Deg2Rad))); // T�y B?c
    }
}
