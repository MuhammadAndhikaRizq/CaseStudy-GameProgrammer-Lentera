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
        Debug.Log("Puzzle opened");
        puzzlePanel.SetActive(true);
        interactionUI.SetActive(false);

        if (interactor.TryGetComponent(out PlayerController controller))
        {
            controller.SetState(PlayerState.Interacting);
        }
    }

    public void ShowHighlight(bool show)
    {
        if (interactionUI != null) interactionUI.SetActive(show);
    }
}
