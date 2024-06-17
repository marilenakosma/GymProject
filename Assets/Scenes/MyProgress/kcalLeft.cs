using UnityEngine;
using TMPro;

public class SubtractValues : MonoBehaviour
{
    public TextMeshProUGUI inputText1; // Το πρώτο πεδίο κειμένου για την εισαγωγή της πρώτης τιμής
    public TextMeshProUGUI inputText2; // Το δεύτερο πεδίο κειμένου για την εισαγωγή της δεύτερης τιμής
    public TextMeshProUGUI resultText; // Το πεδίο κειμένου για την εμφάνιση του αποτελέσματος

    void Update()
    {
        // Ελέγχουμε αν υπάρχουν τιμές στα πεδία κειμένου
        if (inputText1 != null && inputText2 != null && resultText != null)
        {
            // Μετατροπή των κειμένων σε αριθμούς (χρησιμοποιούμε TryParse για ασφάλεια)
            if (float.TryParse(inputText1.text, out float value1) && float.TryParse(inputText2.text, out float value2))
            {
                // Υπολογισμός της διαφοράς
                float difference = value1 - value2;

                // Εμφάνιση του αποτελέσματος στο πεδίο κειμένου
                resultText.text = difference.ToString();
            }
            else
            {
                Debug.LogWarning("Input values are not valid numbers.");
                resultText.text = "Error: Invalid input";
            }
        }
        else
        {
            Debug.LogWarning("One or more TextMeshProUGUI fields are not assigned.");
        }
    }
}
