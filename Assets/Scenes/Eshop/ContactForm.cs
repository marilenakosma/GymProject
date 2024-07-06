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
        errorMessageText.text = "";
        successMessageText.text = "";

        string fullName = fullNameInputField.text;
        string phoneNumber = phoneNumberInputField.text;
        string message = messageInputField.text;

        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
        {
            errorMessageText.text = "Please fill out all fields.";
        }
        else if (phoneNumber.Length != 10)
        {
            errorMessageText.text = "Phone Number must be 10 characters long";
        }
        else
        {
            successMessageText.text = "Thank you for contacting us!";
        }
    }
}

