using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable currentInteractable;
    [SerializeField] private PlayerInputReader inputReader;
    private bool isInsideZone = false;

    private void Awake()
    {
        if (inputReader == null)
        {
            inputReader = GetComponentInParent<PlayerInputReader>();
        }
    }

    private void OnEnable()
    {
        if (inputReader != null)
        {
            inputReader.OnInteractPerformed += HandleInteract;
        }
    }

    private void OnDisable()
    {
        if (inputReader != null)
        {
            inputReader.OnInteractPerformed -= HandleInteract;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered with: " + other.gameObject.name);
        if (other.TryGetComponent(out IInteractable interactable))
        {
            isInsideZone = true;
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
            isInsideZone = false;
            if (currentInteractable == interactable)
            {
                currentInteractable.ShowHighlight(false);
                currentInteractable = null;
            }
        }
    }

    private void HandleInteract()
    {
        if (!isInsideZone) return;
    
        if (currentInteractable != null)
        {
            currentInteractable.Interact(this.gameObject);
        }
    }
}