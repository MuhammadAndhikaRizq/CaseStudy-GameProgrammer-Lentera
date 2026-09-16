using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader input;
    [SerializeField] private float moveSpeed = 5f;

    public float CurrentSpeed { get; private set; }

    private void Update()
    {
        Vector2 moveInput = input.Move;

        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        CurrentSpeed = movement.magnitude;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}