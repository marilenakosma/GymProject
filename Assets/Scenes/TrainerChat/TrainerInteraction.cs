using UnityEngine;
using TMPro;

public class TrainerInteraction : MonoBehaviour
{
    public GameObject TrainerTextImagePrefab; // Reference to the prefab for the background image
    public GameObject TrainerTextPrefab; // Reference to the prefab for the trainer's text response
    public UserResponseHandler userResponseHandler; // Reference to the UserResponseHandler script

    private Vector3 nextPosition = Vector3.zero; // Position for the next chat item

    // Method to display the trainer's response
    public void DisplayTrainerResponse(string response)
    {
        // Instantiate the background image prefab
        GameObject newImage = Instantiate(TrainerTextImagePrefab, userResponseHandler.chatContent);

        // Set the position of the new image based on the nextPosition
        RectTransform imageRect = newImage.GetComponent<RectTransform>();
        if (imageRect != null)
        {
            imageRect.anchoredPosition = nextPosition;
        }

        // Instantiate the text prefab for trainer's response
        GameObject newText = Instantiate(TrainerTextPrefab, userResponseHandler.chatContent);

        // Set the position of the new text relative to the chatContent
        RectTransform textRect = newText.GetComponent<RectTransform>();
        if (textRect != null)
        {
            // Set position relative to the chatContent (adjust as needed)
            textRect.anchoredPosition = nextPosition + new Vector3(0f, -73f, 0f);
        }

        // Set the text of the text prefab to the trainer's response
        TMP_Text textComponent = newText.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = response;
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found in TrainerTextPrefab.");
        }

        // Update nextPosition for the next chat item
        nextPosition += new Vector3(0f, -imageRect.rect.height - 5f, 0f);
    }
}







