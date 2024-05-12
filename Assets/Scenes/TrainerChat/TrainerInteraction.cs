using UnityEngine;
using TMPro;

public class TrainerInteraction : MonoBehaviour
{
    public GameObject TrainerTextImagePrefab; // Reference to the prefab for the text image
    public GameObject TrainerTextPrefab; // Reference to the prefab for the trainer's text
    public GameObject TrainerBackgroundImagePrefab; // Reference to the prefab for the background image
    public GameObject TrainerImagePrefab; // Reference to the prefab for the trainer's image
    public Transform chatContent; // Reference to the content area where chat items will be placed

    private Vector3 nextPosition = Vector3.zero; // Position for the next chat item

    // Method to display the trainer's response
    public void DisplayTrainerResponse(string response)
    {
        // Instantiate the text image prefab
        GameObject newTextImage = Instantiate(TrainerTextImagePrefab, chatContent);

        // Set the position of the new text image relative to the chatContent
        RectTransform textImageRect = newTextImage.GetComponent<RectTransform>();
        if (textImageRect != null)
        {
            // Set position relative to the chatContent (adjust as needed)
            textImageRect.anchoredPosition = nextPosition;
        }

        // Instantiate the text prefab for trainer's response
        GameObject newText = Instantiate(TrainerTextPrefab, chatContent);

        // Set the position of the new text relative to the chatContent
        RectTransform textRect = newText.GetComponent<RectTransform>();
        if (textRect != null)
        {
            // Set position relative to the chatContent (adjust as needed)
            textRect.anchoredPosition = nextPosition;
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
        nextPosition += new Vector3(0f, -textRect.rect.height - 5f, 0f);
    }
}











