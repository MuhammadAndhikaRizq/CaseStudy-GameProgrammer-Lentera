using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    // [SerializeField] private PlayerController controller;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsDriving = Animator.StringToHash("IsDriving");
    private static readonly int IsSitting = Animator.StringToHash("IsSitting");
    private static readonly int Interact = Animator.StringToHash("Interact");

    private void Update()
    {
        UpdateMovementAnimation();
        // UpdateStateAnimation();
    }

    private void UpdateMovementAnimation()
    {
        animator.SetFloat(Speed, movement.NormalizedSpeed, 0.1f, Time.deltaTime);
    }

    // private void UpdateStateAnimation()
    // {
    //     animator.SetBool(
    //         IsDriving,
    //         controller.CurrentState == PlayerState.Driving
    //     );

    //     animator.SetBool(
    //         IsSitting,
    //         controller.CurrentState == PlayerState.Sitting
    //     );
    // }

    public void PlayInteract()
    {
        animator.SetTrigger(Interact);
    }
}