using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInputReader input;
    [SerializeField] private PlayerController playerController;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Transform cameraTransform;

    public float CurrentSpeed { get; private set; }
    public float NormalizedSpeed => moveSpeed > 0f ? CurrentSpeed / moveSpeed : 0f;

    private void Update()
    {
        if (playerController.CurrentState == PlayerState.Interacting)
        {
            CurrentSpeed = 0f; 
            return; 
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = input.Move;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement =
            forward * moveInput.y +
            right * moveInput.x;

        if (movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }

        float targetSpeed = movement.magnitude * moveSpeed;

        CurrentSpeed = Mathf.MoveTowards(
            CurrentSpeed,
            targetSpeed,
            acceleration * Time.deltaTime
        );

        if (movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        transform.position +=
            movement.normalized *
            CurrentSpeed *
            Time.deltaTime;
    }
}