using UnityEngine;
using TMPro;

public class UserResponseHandler : MonoBehaviour
{
    public GameObject userTextPrefab; // Reference to the prefab for the user's text response
    public Transform chatContent; // Reference to the content area where chat items will be placed

    // Method to handle user response
    public void HandleUserResponse(string option)
    {
        // Instantiate the user text prefab
        GameObject newUserText = Instantiate(userTextPrefab, chatContent);

        // Set the text component of the user text prefab to the chosen option
        TMP_Text userTextComponent = newUserText.GetComponentInChildren<TMP_Text>();
        if (userTextComponent != null)
        {
            userTextComponent.text = option;
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found in UserTextPrefab.");
        }

        // Position the user text prefab as needed within the chat interface
        // You can adjust the position based on the current layout and design
        // For example, you might use anchoredPosition to position it relative to the chatContent.
    }
}

