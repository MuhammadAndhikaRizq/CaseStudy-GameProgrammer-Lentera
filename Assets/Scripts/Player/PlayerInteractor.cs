using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable currentInteractable;
    private PlayerInputReader inputReader;

    private void Awake()
    {
        inputReader = GetComponent<PlayerInputReader>();
    }

    private void OnEnable()
    {
        inputReader.OnInteractPerformed += TryInteract;
    }

    private void OnDisable()
    {
        inputReader.OnInteractPerformed -= TryInteract;
    }

    private void TryInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (currentInteractable != null)
                currentInteractable.ShowHighlight(false);

            currentInteractable = interactable;
            currentInteractable.ShowHighlight(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (currentInteractable == interactable)
            {
                currentInteractable.ShowHighlight(false);
                currentInteractable = null;
            }
        }
    }
}