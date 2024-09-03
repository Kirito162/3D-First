using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f; // T?c ?? dash
    public float dashDuration = 0.2f; // Th?i gian dash
    private CharacterController characterController;
    private Vector3 dashDirection;
    private bool isDashing = false;
    private float dashTime;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        dashDirection = transform.forward; // H??ng dash theo h??ng Player ?ang nhìn
    }

    void Dash()
    {
        if (dashTime > 0)
        {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
            dashTime -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
        }
    }
}
