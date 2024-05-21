using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FAQManager : MonoBehaviour
{
    public Button[] questionButtons; 
    public GameObject trainerTextPrefab; 
    public GameObject trainerImagePrefab; 
    public Transform contentPanel;

    private string[] questions = {
        "How are you?",
        "What's your name?",
        "What's the weather like?",
        "What are the best exercises for building chest muscles?",
        "How do I perform a bench press correctly?"
    };

    private string[] answers = {
        "I'm doing well, thank you!",
        "My name is Trainer.",
        "The weather is sunny today.",
        "The best exercises for building chest muscles are bench press, push-ups, and chest flyes.",
        "To perform a bench press correctly, lie on the bench with your feet flat on the ground, grip the bar slightly wider than shoulder-width apart, and lower the bar to your chest before pressing it back up."
    };

    private Vector2 trainerImagePosition = new Vector2(-10f, 266f); 
    private Vector2 trainerTextPosition = new Vector2(300f, 266f); 

    void Start()
    {
        SetupQuestionButtons();
    }

    void SetupQuestionButtons()
    {
        for (int i = 0; i < questionButtons.Length && i < questions.Length; i++)
        {
            TMP_Text buttonText = questionButtons[i].GetComponentInChildren<TMP_Text>();

            if (buttonText != null)
            {
                buttonText.text = questions[i];
            }
            else
            {
                Debug.LogError("TMP_Text component not found in question button.");
                continue; 
            }

          
            int index = i; 
            questionButtons[i].onClick.AddListener(() => ShowTrainerResponse(index));
        }
    }

    void ShowTrainerResponse(int index)
    {
        if (index < 0 || index >= answers.Length)
        {
            Debug.LogError("Invalid index: " + index);
            return;
        }

       
        GameObject trainerImage = Instantiate(trainerImagePrefab, contentPanel);
        if (trainerImage == null)
        {
            Debug.LogError("Failed to instantiate trainerImagePrefab.");
            return;
        }

        RectTransform imageRect = trainerImage.GetComponent<RectTransform>();
        if (imageRect != null)
        {
            
            imageRect.anchoredPosition = new Vector2(trainerImagePosition.x, trainerImagePosition.y - index * 150f);
        }
        else
        {
            Debug.LogError("RectTransform component not found in trainerImagePrefab.");
        }

       
        GameObject trainerText = Instantiate(trainerTextPrefab, contentPanel);
        if (trainerText == null)
        {
            Debug.LogError("Failed to instantiate trainerTextPrefab.");
            return;
        }

        TMP_Text trainerTextComponent = trainerText.GetComponentInChildren<TMP_Text>();
        if (trainerTextComponent == null)
        {
            Debug.LogError("TMP_Text component not found in trainerTextPrefab.");
            return;
        }

        try
        {
            trainerTextComponent.text = answers[index];
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error setting text: " + ex.Message);
        }

        RectTransform textRect = trainerText.GetComponent<RectTransform>();
        if (textRect != null)
        {
           
            textRect.anchoredPosition = new Vector2(trainerTextPosition.x, trainerTextPosition.y - index * 150f);
        }
        else
        {
            Debug.LogError("RectTransform component not found in trainerTextPrefab.");
        }
    }
}
















