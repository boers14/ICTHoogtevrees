using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    // Reference to the UI Text component
    public Text messageText;

    void Start()
    {
        // Example: Setting text on start
        messageText.text = "Welcome to the Game!";
    }

    // Example: Method to update text dynamically
    public void UpdateText(string newText)
    {
        messageText.text = newText;
    }
}
