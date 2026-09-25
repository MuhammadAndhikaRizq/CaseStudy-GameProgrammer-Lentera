using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public event Action OnInteractPerformed; 

    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();

        inputActions.Player.Move.performed += ctx => Move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => Move = Vector2.zero;

        inputActions.Player.Look.performed += ctx => Look = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => Look = Vector2.zero;

        inputActions.Player.Interact.performed += ctx => 
        {

            OnInteractPerformed?.Invoke();
        };
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

}
