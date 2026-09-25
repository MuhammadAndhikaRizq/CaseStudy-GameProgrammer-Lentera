using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPuzzleManager : MonoBehaviour
{
    [Header("Card Setup")]
    [SerializeField] private List<MemoryPuzzle> allCards; 
    [SerializeField] private Sprite[] cardSprites; 
    
    [Header("References")]
    [SerializeField] private InteractObject interactSource;

    private MemoryPuzzle firstRevealed;
    private MemoryPuzzle secondRevealed;
    private int matchCount = 0;
    private bool isChecking = false;

    private void OnEnable()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        matchCount = 0;
        isChecking = false;
        firstRevealed = null;
        secondRevealed = null;

        List<int> idPairs = new List<int>();
        for (int i = 0; i < allCards.Count / 2; i++)
        {
            idPairs.Add(i);
            idPairs.Add(i);
        }

        for (int i = 0; i < idPairs.Count; i++)
        {
            int temp = idPairs[i];
            int randomIndex = Random.Range(i, idPairs.Count);
            idPairs[i] = idPairs[randomIndex];
            idPairs[randomIndex] = temp;
        }

        for (int i = 0; i < allCards.Count; i++)
        {
            allCards[i].SetupCard(idPairs[i], cardSprites[idPairs[i]], this);
        }
    }

    public void CardRevealed(MemoryPuzzle card)
    {
        if (isChecking) return; 

        card.ShowCard();

        if (firstRevealed == null)
        {
            firstRevealed = card;
        }
        else if (secondRevealed == null)
        {
            secondRevealed = card;
            StartCoroutine(CheckMatchCoroutine());
        }
    }

    private IEnumerator CheckMatchCoroutine()
    {
        isChecking = true;
        
        yield return new WaitForSeconds(1f); 

        if (firstRevealed.CardID == secondRevealed.CardID)
        {
            matchCount++;
            if (matchCount == allCards.Count / 2)
            {
                Debug.Log("Memory Match Selesai!");
                CloseAndUnfreeze();
            }
        }
        else
        {
            firstRevealed.HideCard();
            secondRevealed.HideCard();
        }

        firstRevealed = null;
        secondRevealed = null;
        isChecking = false;
    }

    public void CloseAndUnfreeze()
    {
        if (interactSource != null && PlayerController.Instance != null)
        {
            interactSource.ClosePuzzle(PlayerController.Instance);
        }
    }
}
