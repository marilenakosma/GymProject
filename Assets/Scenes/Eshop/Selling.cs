using UnityEngine;
using TMPro;
using System;

public class Selling : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_InputField CardNumberInputField;
    public TMP_InputField ExpirationDateInputField;
    public TMP_InputField CVVInputField;

    public TMP_Text errorMessageText;
    public TMP_Text successMessageText;

    public void OnSubmitButtonClicked()
    {
        // Clear previous messages
        errorMessageText.text = "";
        successMessageText.text = "";

        // Get the values from input fields
        string Name = NameInputField.text;
        string CardNumber = CardNumberInputField.text;
        string ExpDate = ExpirationDateInputField.text;
        string CVV =CVVInputField.text;

        // Check for empty fields
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(ExpDate) || string.IsNullOrWhiteSpace(CVV))
        {
            errorMessageText.text = "Please fill out all fields.";
        }
        else if(CardNumber.Length != 16)
        {
            errorMessageText.text = "Card Number must be 16 characters";
        }
        else if(CVV.Length !=3)
        {
            errorMessageText.text = "CVV must be 3 characters";
        }
        else
        {
            successMessageText.text = "Thank you for shopping with us!";
        }
    }
}
