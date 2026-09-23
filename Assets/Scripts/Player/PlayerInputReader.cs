using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }

    // public event Action OnJumpPerformed;
    public event Action OnInteractPerformed;
    // public event Action<bool> OnSprintChanged; 

    public void OnMove(InputValue value)
    {
        Move = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        Look = value.Get<Vector2>();
    }

    // public void OnJump(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         OnJumpPerformed?.Invoke();
    //     }
    // }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            OnInteractPerformed?.Invoke();
        }
    }

    // public void OnSprint(InputValue value)
    // {
    //     OnSprintChanged?.Invoke(value.isPressed);
    // }
}
