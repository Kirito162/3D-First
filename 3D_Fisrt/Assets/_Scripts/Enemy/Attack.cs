using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Attack : StateMachineBehaviour
{
    public EnemyDetection enemyDetection;

    public float outRangeAttack = 4f;
    //private float lastNormalizedTime = 0f;
    public string[] animationNames;
    bool isAttacking;
    float timer;
    [SerializeField] float timeDelayAttack = 0.5f;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyDetection = animator.GetComponent<EnemyDetection>();
        //lastNormalizedTime = 0f;
        isAttacking = false;
        timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        Transform target = enemyDetection.GetClosestEnemy();
        if (target != null) 
        {
            //animator.transform.LookAt(target);
            float distance = Vector3.Distance(target.position, animator.transform.position);
            if (distance > outRangeAttack)
            {
                animator.SetBool("isAttacking", false);
            }
            else if (!isAttacking && timer >= timeDelayAttack)
            {
                //animator.transform.LookAt(target.position);
                // Xoay ch? trong m?t ph?ng ngang (không xoay theo tr?c Y)
                Vector3 directionToTarget = target.position - animator.transform.position;
                directionToTarget.y = 0; // Lo?i b? thay ??i ?? cao
                animator.transform.rotation = Quaternion.LookRotation(directionToTarget);

                PlayRandomAnimation(animator);
                isAttacking = true;
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
        /*if (stateInfo.normalizedTime % 1 <= lastNormalizedTime)
        {
            animator.transform.LookAt(target);
        }

        lastNormalizedTime = stateInfo.normalizedTime % 1;*/
        

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*Transform target = enemyDetection.GetClosestEnemy();
        animator.gameObject.transform.LookAt(target);*/
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
