using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
      public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool Jump { get; private set; }
    public bool Sprint { get; private set; }
    public bool Crouch { get; private set; }

    public void OnMove(InputValue value)
    {
        Move = value.Get<Vector2>();

        Debug.Log($"Move: {Move}");
    }

    public void OnLook(InputValue value)
    {
        Look = value.Get<Vector2>();

        Debug.Log($"Look: {Look}");
    }

    public void OnJump(InputValue value)
    {
        Jump = value.isPressed;
    }

    public void OnSprint(InputValue value)
    {
        Sprint = value.isPressed;
    }

    public void OnCrouch(InputValue value)
    {
        Crouch = value.isPressed;
    }
}
