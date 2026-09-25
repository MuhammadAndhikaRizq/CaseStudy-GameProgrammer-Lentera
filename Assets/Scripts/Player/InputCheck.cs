using UnityEngine;
using UnityEngine.InputSystem;

public class InputCheck : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Test Input tombol E keyboard");
        }
    }
}