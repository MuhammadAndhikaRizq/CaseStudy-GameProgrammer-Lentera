using UnityEngine;

public class InteractObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactionUI;
    [Header("Puzzle Panel")]
    [SerializeField] private GameObject puzzlePanel;

    private void Start()
    {
        if (interactionUI != null) interactionUI.SetActive(false);
        if (puzzlePanel != null) puzzlePanel.SetActive(false);
    }

   public void Interact(GameObject interactor)
    {
        if (interactor.TryGetComponent(out PlayerController controller))
        {
            controller.SetState(PlayerState.Interacting);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        
        interactionUI.SetActive(false);
        puzzlePanel.SetActive(true);
    }

    public void ShowHighlight(bool show)
    {
        if (interactionUI != null) interactionUI.SetActive(show);
    }

    public void ClosePuzzle(PlayerController controller)
    {
        puzzlePanel.SetActive(false);
        
        controller.SetState(PlayerState.Walking);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
