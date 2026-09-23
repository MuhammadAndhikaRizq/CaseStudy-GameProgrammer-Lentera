using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Interacting,
    Sitting,
    Driving
}
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public PlayerState CurrentState { get; private set;}
    [SerializeField] private PlayerMovement movement;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void Start()
    {
        CurrentState = PlayerState.Idle;
    }

    public void SetState(PlayerState newState)
    {
        CurrentState = newState;

        if (CurrentState == PlayerState.Interacting)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (CurrentState == PlayerState.Idle || CurrentState == PlayerState.Walking)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}