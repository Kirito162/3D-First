using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : StateMachineBehaviour
{
    public EnemyDetection enemyDetection;

    /*public float outRangeAttack = 4f;
    private float lastNormalizedTime = 0f;
     OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyDetection = animator.GetComponent<EnemyDetection>();
        lastNormalizedTime = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = enemyDetection.GetClosestEnemyInView();
        if (target != null) 
        {
            //animator.transform.LookAt(target);
            float distance = Vector3.Distance(target.position, animator.transform.position);
            if (distance > outRangeAttack)
                animator.SetBool("ClawAttack", false);
        }
        if (stateInfo.normalizedTime % 1 <= lastNormalizedTime)
        {
            animator.transform.LookAt(target);
        }
        lastNormalizedTime = stateInfo.normalizedTime % 1;

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }*/

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyDetection = animator.GetComponent<EnemyDetection>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = enemyDetection.GetClosestEnemyInView();
        animator.transform.LookAt(target);

    }

}
