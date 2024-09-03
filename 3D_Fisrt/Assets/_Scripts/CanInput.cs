using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInput : StateMachineBehaviour
{
    public PlayerController controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<PlayerController>();
        //controller.DisableInput();
        controller.canMove = false;
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //controller.EnableInput();
        controller.canMove = true;
    }


}
