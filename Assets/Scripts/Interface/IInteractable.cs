using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject interactor);
    void ShowHighlight(bool show);
}