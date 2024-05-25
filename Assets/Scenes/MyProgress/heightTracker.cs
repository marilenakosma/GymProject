using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class UserInputHandler : MonoBehaviour
{
    public TMP_InputField userInputField;
    public TextMeshProUGUI displayText;
    public Button saveButton;
    public Button editButton;

    // Δημιουργία μιας δομής για την αποθήκευση ύψους και ημερομηνίας
    [Serializable]
    public struct HeightEntry
    {
        public float height;
        public DateTime date;

        public HeightEntry(float height, DateTime date)
        {
            this.height = height;
            this.date = date;
        }
    }

    // Λίστα για την αποθήκευση των καταχωρήσεων ύψους
    public List<HeightEntry> heightEntries = new List<HeightEntry>();

    void Start()
    {
        // Απόκρυψη του πεδίου εισαγωγής και του κουμπιού αποθήκευσης αρχικά
        userInputField.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);

        // Προσθήκη ακροατή στο πεδίο εισαγωγής για να ανιχνεύει τις αλλαγές
        userInputField.onEndEdit.AddListener(HandleUserInput);

        // Προσθήκη ακροατή στο κουμπί "save" για να ανιχνεύει το πάτημα του κουμπιού
        saveButton.onClick.AddListener(SaveHeightEntry);

        // Προσθήκη ακροατή στο κουμπί "edit" για να ανιχνεύει το πάτημα του κουμπιού
        editButton.onClick.AddListener(EditEntry);
    }

    void HandleUserInput(string input)
    {
        // Εμφανίζει την εισαγωγή του χρήστη στο UI
        displayText.text = input;

        // Άλλες ενέργειες με την εισαγωγή του χρήστη
        Debug.Log("User input: " + input);
    }

    void SaveHeightEntry()
    {
        // Παίρνουμε το ύψος από το πεδίο εισαγωγής
        if (float.TryParse(userInputField.text, out float height))
        {
            // Παίρνουμε τη σημερινή ημερομηνία
            DateTime today = DateTime.Today;

            // Δημιουργία μιας νέας καταχώρησης ύψους με τη σημερινή ημερομηνία
            HeightEntry newEntry = new HeightEntry(height, today);

            // Προσθήκη της καταχώρησης στη λίστα
            heightEntries.Add(newEntry);

            // Εμφανίζουμε μόνο το ύψος
            displayText.text = height.ToString();

            // Άλλες ενέργειες με την καταχώρηση
            Debug.Log($"Saved height: {height} cm on {today.ToString("dd/MM/yyyy")}");
        }
        else
        {
            // Εμφανίζουμε μήνυμα λάθους αν η είσοδος δεν είναι έγκυρος αριθμός
            displayText.text = "Invalid input. Please enter a valid number.";
            Debug.Log("Invalid input. Please enter a valid number.");
        }

        // Απόκρυψη του πεδίου εισαγωγής και του κουμπιού αποθήκευσης
        userInputField.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);

        // Εμφάνιση του κουμπιού επεξεργασίας
        editButton.gameObject.SetActive(true);
    }

    void EditEntry()
    {
        // Εμφάνιση του πεδίου εισαγωγής και του κουμπιού αποθήκευσης
        userInputField.gameObject.SetActive(true);
        saveButton.gameObject.SetActive(true);

        // Απόκρυψη του κουμπιού επεξεργασίας
        editButton.gameObject.SetActive(false);
    }
}
