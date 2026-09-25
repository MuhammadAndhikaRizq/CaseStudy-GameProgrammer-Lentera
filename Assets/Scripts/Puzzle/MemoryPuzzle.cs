using UnityEngine;
using UnityEngine.UI;

public class MemoryPuzzle : MonoBehaviour
{
    [SerializeField] private Image cardImage; 
    [SerializeField] private Sprite hiddenSprite; 
    
    public int CardID { get; private set; } 
    private Sprite revealSprite; 
    private MemoryPuzzleManager manager;

    public void SetupCard(int id, Sprite reveal, MemoryPuzzleManager managerRef)
    {
        CardID = id;
        revealSprite = reveal;
        manager = managerRef;
        HideCard();
    }

    public void OnCardClicked()
    {
        manager.CardRevealed(this);
    }

    public void ShowCard()
    {
        cardImage.sprite = revealSprite;
        GetComponent<Button>().interactable = false; 
    }

    public void HideCard()
    {
        cardImage.sprite = hiddenSprite;
        GetComponent<Button>().interactable = true;
    }
}
