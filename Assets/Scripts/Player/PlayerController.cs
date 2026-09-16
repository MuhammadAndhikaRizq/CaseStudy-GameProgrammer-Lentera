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
    public PlayerState CurrentState { get; private set;}
    [SerializeField] private PlayerMovement movement;

    private void Start()
    {
        CurrentState = PlayerState.Idle;
    }

    public void SetState(PlayerState newState)
    {
        CurrentState = newState;
    }
}