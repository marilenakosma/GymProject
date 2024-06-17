using UnityEngine;
using TMPro;

public class CalorieCalculator : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public TextMeshProUGUI totalCaloriesText;

    void Update()
    {
        float totalCalories = 0f;

        // Check each input field if it is not interactable and add its calories
        if (!input1.interactable)
        {
            totalCalories += GetCalories(input1);
        }

        if (!input2.interactable)
        {
            totalCalories += GetCalories(input2);
        }

        if (!input3.interactable)
        {
            totalCalories += GetCalories(input3);
        }

        // Display the total calories
        totalCaloriesText.text = totalCalories.ToString();
    }

    float GetCalories(TMP_InputField inputField)
    {
        // If the input field is empty or null, return 0
        if (string.IsNullOrEmpty(inputField.text))
        {
            return 0f;
        }

        // Try to parse the text to a float value
        float calories;
        if (float.TryParse(inputField.text, out calories))
        {
            return calories;
        }

        // If parsing fails, return 0
        return 0f;
    }
}
