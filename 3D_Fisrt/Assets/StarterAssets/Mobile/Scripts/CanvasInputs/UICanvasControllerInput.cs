using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public StarterAssetsInputs starterAssetsInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }
        public void VirtualSkill_1Input(bool virtualSkill1State)
        {
            starterAssetsInputs.Skill_1Input(virtualSkill1State);
        }
        public void VirtualTargetInput(bool virtualTargetState)
        {
            starterAssetsInputs.TargetInput(virtualTargetState);
        }
        public void VirtualSkill_2Input(bool virtualSkill2State)
        {
            starterAssetsInputs.Skill_2Input(virtualSkill2State);
        }
    }

}
