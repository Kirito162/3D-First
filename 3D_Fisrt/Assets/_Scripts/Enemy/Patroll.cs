using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroll : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent navMeshAgent;
    public float chaseRange = 8;
    public EnemyDetection enemyDetection;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }
        navMeshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        enemyDetection = animator.GetComponent<EnemyDetection>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
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


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
