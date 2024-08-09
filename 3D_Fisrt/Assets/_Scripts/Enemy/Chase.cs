using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : StateMachineBehaviour
{
    NavMeshAgent navMeshAgent;
    public EnemyDetection enemyDetection;
    public float attackRange = 4f;
    public float chaseRangeOut = 15f;
    public float speedChase = 3.5f;
    public string[] animationNames;
    bool isAttacking;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speedChase;
        enemyDetection = animator.GetComponent<EnemyDetection>();
        isAttacking = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Transform target = enemyDetection.GetClosestEnemy();
        if (target != null ) 
        {
            navMeshAgent.SetDestination(target.position);
            float distance = Vector3.Distance(target.position, animator.transform.position);
            if (distance > chaseRangeOut)
                animator.SetBool("isChasing", false);
            if (distance < attackRange && !isAttacking)
            {
                animator.transform.LookAt(target.position);
                //animator.SetBool("isAttacking", true);
                //isAttacking = true;
                PlayRandomAnimation(animator);
                
            }
                
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.SetDestination(animator.transform.position);
    }

    void PlayRandomAnimation(Animator animator)
    {
        if (animationNames.Length == 0)
        {
            Debug.LogWarning("No animations found!");
            return;
        }

        int randomIndex = Random.Range(0, animationNames.Length);
        string randomAnimation = animationNames[randomIndex];

        animator.SetTrigger(randomAnimation);
    }
}
