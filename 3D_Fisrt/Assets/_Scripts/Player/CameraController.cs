
using UnityEngine;
using UnityEngine.InputSystem;
namespace StarterAssets
{
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif


    public class CameraController : MonoBehaviour
    {
        public GameObject CinemachineCameraTarget;
        public float TopClamp = 70.0f;
        public float BottomClamp = -30.0f;
        public float CameraAngleOverride = 0.0f;
        public bool LockCameraPosition = false;

        private StarterAssetsInputs _input;
        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;
        private const float _threshold = 0.01f;
        [Header("Mouse Sensitivity")]
        [Tooltip("Sensitivity of the mouse for camera movement")]
        public float MouseSensitivity = 1.0f;

#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerInput;
#endif
        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }

        private void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
            _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
#if ENABLE_INPUT_SYSTEM
            _playerInput = GetComponentInParent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
        }

        public void CameraRotation()
        {
            // if there is an input and camera position is not fixed
            if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                //Don't multiply mouse input by Time.deltaTime;
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier * MouseSensitivity; ;
                _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier * MouseSensitivity; ;
            }

            // clamp our rotations so our values are limited 360 degrees
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Cinemachine will follow this target
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}
