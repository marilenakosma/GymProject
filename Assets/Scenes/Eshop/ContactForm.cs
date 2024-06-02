using UnityEngine;
using TMPro;

public class ContactForm : MonoBehaviour
{
    public TMP_InputField fullNameInputField;
    public TMP_InputField phoneNumberInputField;
    public TMP_InputField messageInputField;

    public TMP_Text errorMessageText;
    public TMP_Text successMessageText;

    public void OnSubmitButtonClicked()
    {
        // Clear previous messages
        errorMessageText.text = "";
        successMessageText.text = "";

        // Get the values from input fields
        string fullName = fullNameInputField.text;
        string phoneNumber = phoneNumberInputField.text;
        string message = messageInputField.text;

        // Check for empty fields
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
        {
            errorMessageText.text = "Please fill out all fields.";
        }
        else
        {
            successMessageText.text = "Thank you for contacting us!";
        }
    }
}

