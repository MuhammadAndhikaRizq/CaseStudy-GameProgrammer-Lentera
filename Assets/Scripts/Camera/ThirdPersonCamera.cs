using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Camera Distance")]
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2f;

    [Header("Look")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float minPitch = -30f;
    [SerializeField] private float maxPitch = 70f;

    [Header("Smoothing")]
    [SerializeField] private float positionSmoothTime = 0.08f;
    [SerializeField] private float rotationSmoothTime = 0.05f;

    private PlayerInputReader input;

    private float yaw;
    private float pitch;

    private float currentYaw;
    private float currentPitch;

    private float yawVelocity;
    private float pitchVelocity;

    private Vector3 positionVelocity;

    private void Start()
    {
        input = target.GetComponentInParent<PlayerInputReader>();

        currentYaw = yaw;
        currentPitch = pitch;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (PlayerController.Instance.CurrentState == PlayerState.Interacting)
        {
            return; 
        }
        
        HandleLook();
        HandleCameraPosition();
    }

    private void HandleLook()
    {
        Vector2 lookInput = input.Look;

        yaw += lookInput.x * sensitivity;
        pitch -= lookInput.y * sensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        currentYaw = Mathf.SmoothDampAngle(
            currentYaw,
            yaw,
            ref yawVelocity,
            rotationSmoothTime
        );

        currentPitch = Mathf.SmoothDamp(
            currentPitch,
            pitch,
            ref pitchVelocity,
            rotationSmoothTime
        );
    }

    private void HandleCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        Vector3 desiredPosition =
            target.position
            + rotation * new Vector3(0f, height, -distance);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref positionVelocity,
            positionSmoothTime
        );

        transform.rotation = rotation;
    }
}