using UnityEngine;
using TMPro;

public class NumpadPuzzle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string correctPasscode;
    [SerializeField] private int maxDigits = 4;
    
    [Header("UI References")]
    [SerializeField] private TMP_Text displayInputText;
    [SerializeField] private InteractObject interactSource; 

    private string currentInput = "";

    private void OnEnable()
    {
        ClearInput(); 
    }

    public void AddNumber(string numberString)
    {
        if (currentInput.Length < maxDigits)
        {
            currentInput += numberString;
            UpdateDisplay();
        }
    }

    public void ClearInput()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void SubmitPasscode()
    {
        if (currentInput == correctPasscode)
        {
            displayInputText.color = Color.green;
            
            CloseAndUnfreeze();
        }
        else
        {
            displayInputText.color = Color.red;
            Invoke(nameof(ClearInput), 1f);
        }
    }

    private void UpdateDisplay()
    {
        displayInputText.text = currentInput;
    }

    public void CloseAndUnfreeze()
    {
        if (interactSource != null && PlayerController.Instance != null)
        {
            interactSource.ClosePuzzle(PlayerController.Instance);
        }
    }
}
