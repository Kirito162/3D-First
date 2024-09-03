using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement _movement;
    private SkillManager _skill;
    private CameraController _cameraController;
    public bool canInput = true;
    public bool canMove = true;

    private void Start()
    {
        _movement = GetComponentInChildren<CharacterMovement>();
        _skill = GetComponent<SkillManager>();
        _cameraController = GetComponentInChildren<CameraController>();
    }

    private void Update()
    {
        if (canInput)
        {
            
            _movement.JumpAndGravity();
            _movement.GroundedCheck();
            //_movement.Target();
            _skill.HandleSkills();
            if (canMove)
            {
                _movement.Move();
            }
        }
        
    }
    private void LateUpdate()
    {
        _cameraController.CameraRotation();
    }

    public void DisableInput()
    {
        canInput = false;
    }
    public void EnableInput()
    {
        canInput = true;
    }
    

}
