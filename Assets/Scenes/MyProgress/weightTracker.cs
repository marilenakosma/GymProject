using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class WeightTracker : MonoBehaviour
{
    public TMP_InputField userInputField;
    public TextMeshProUGUI displayText;
    public Button saveButton;
    public Button editButton;

    // Δημιουργία μιας δομής για την αποθήκευση βάρους και ημερομηνίας
    [Serializable]
    public struct WeightEntry
    {
        public float weight;
        public DateTime date;

        public WeightEntry(float weight, DateTime date)
        {
            this.weight = weight;
            this.date = date;
        }
    }

    // Λίστα για την αποθήκευση των καταχωρήσεων βάρους
    public List<WeightEntry> weightEntries = new List<WeightEntry>();

    void Start()
    {
        // Απόκρυψη του πεδίου εισαγωγής και του κουμπιού αποθήκευσης αρχικά
        userInputField.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);

        // Προσθήκη ακροατή στο πεδίο εισαγωγής για να ανιχνεύει τις αλλαγές
        userInputField.onEndEdit.AddListener(HandleUserInput);

        // Προσθήκη ακροατή στο κουμπί "save" για να ανιχνεύει το πάτημα του κουμπιού
        saveButton.onClick.AddListener(SaveWeightEntry);

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

    void SaveWeightEntry()
    {
        // Παίρνουμε το βάρος από το πεδίο εισαγωγής
        if (float.TryParse(userInputField.text, out float weight))
        {
            // Παίρνουμε τη σημερινή ημερομηνία
            DateTime today = DateTime.Today;

            // Δημιουργία μιας νέας καταχώρησης βάρους με τη σημερινή ημερομηνία
            WeightEntry newEntry = new WeightEntry(weight, today);

            // Προσθήκη της καταχώρησης στη λίστα
            weightEntries.Add(newEntry);

            // Εμφανίζουμε μόνο το βάρος
            displayText.text = weight.ToString();

            // Άλλες ενέργειες με την καταχώρηση
            Debug.Log($"Saved weight: {weight} kg on {today.ToString("dd/MM/yyyy")}");
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
