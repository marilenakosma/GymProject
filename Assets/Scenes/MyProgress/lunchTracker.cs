using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LunchEntry : MonoBehaviour
{
    public TMP_InputField foodNameInput;
    public TMP_InputField caloriesInput;
    public Button saveButton;

    void Start()
    {
        // Έλεγχος αν υπάρχουν ήδη αποθηκευμένα δεδομένα για την τρέχουσα ημερομηνία
        string savedDate = PlayerPrefs.GetString("LunchEntryDate", "");

        if (savedDate == DateTime.Today.ToString())
        {
            // Αν υπάρχουν δεδομένα για την τρέχουσα ημερομηνία, απενεργοποιούμε τα πεδία εισόδου και το κουμπί
            foodNameInput.interactable = false;
            caloriesInput.interactable = false;
            saveButton.gameObject.SetActive(false);

            // Εμφάνιση των αποθηκευμένων δεδομένων στα πεδία εισόδου
            string savedFoodName = PlayerPrefs.GetString("LunchFoodName", "No data");
            float savedCalories = PlayerPrefs.GetFloat("LunchCalories", 0f);
            foodNameInput.text = savedFoodName;
            caloriesInput.text = savedCalories.ToString();

            // Εκτύπωση των αποθηκευμένων δεδομένων στην κονσόλα για επιβεβαίωση
            Debug.Log("Already saved data for today:");
            Debug.Log("Lunch Food Name: " + savedFoodName);
            Debug.Log("Lunch Calories: " + savedCalories);
            Debug.Log("Lunch Entry Date: " + savedDate);
        }
        else
        {
            // Αν δεν υπάρχουν δεδομένα, ενεργοποιούμε τα πεδία εισόδου και το κουμπί
            saveButton.onClick.AddListener(SaveFoodEntry);
        }
    }

    public void SaveFoodEntry()
    {
        // Παίρνουμε τα δεδομένα από τα input fields
        string foodName = foodNameInput.text;
        float calories = float.Parse(caloriesInput.text);

        // Αποθηκεύουμε τα δεδομένα για το μεσημεριανό μαζί με την σημερινή ημερομηνία
        PlayerPrefs.SetString("LunchFoodName", foodName);
        PlayerPrefs.SetFloat("LunchCalories", calories);
        PlayerPrefs.SetString("LunchEntryDate", DateTime.Today.ToString());

        // Εκτύπωση των δεδομένων στην κονσόλα
        Debug.Log("Lunch Food Name: " + foodName);
        Debug.Log("Lunch Calories: " + calories);
        Debug.Log("Lunch Entry Date: " + DateTime.Today.ToString());

        // Απενεργοποίηση των πεδίων εισόδου και του κουμπιού
        foodNameInput.interactable = false;
        caloriesInput.interactable = false;
        saveButton.gameObject.SetActive(false);
    }
}
