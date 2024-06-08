using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DinnerEntry : MonoBehaviour
{
    public TMP_InputField foodNameInput;
    public TMP_InputField caloriesInput;
    public Button saveButton;

    void Start()
    {
        // Έλεγχος αν υπάρχουν ήδη αποθηκευμένα δεδομένα για την τρέχουσα ημερομηνία
        string savedDate = PlayerPrefs.GetString("DinnerEntryDate", "");

        if (savedDate == DateTime.Today.ToString("d"))
        {
            // Αν υπάρχουν δεδομένα για την τρέχουσα ημερομηνία, απενεργοποιούμε τα πεδία εισόδου και το κουμπί
            foodNameInput.interactable = false;
            caloriesInput.interactable = false;
            saveButton.gameObject.SetActive(false);

            // Εμφάνιση των αποθηκευμένων δεδομένων στα πεδία εισόδου
            string savedFoodName = PlayerPrefs.GetString("DinnerFoodName", "No data");
            float savedCalories = PlayerPrefs.GetFloat("DinnerCalories", 0f);
            foodNameInput.text = savedFoodName;
            caloriesInput.text = savedCalories.ToString();

            // Εκτύπωση των αποθηκευμένων δεδομένων στην κονσόλα για επιβεβαίωση
            Debug.Log("Already saved data for today:");
            Debug.Log("Dinner Food Name: " + savedFoodName);
            Debug.Log("Dinner Calories: " + savedCalories);
            Debug.Log("Dinner Entry Date: " + savedDate);
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

        // Αποθηκεύουμε τα δεδομένα για το βραδινό μαζί με την σημερινή ημερομηνία
        PlayerPrefs.SetString("DinnerFoodName", foodName);
        PlayerPrefs.SetFloat("DinnerCalories", calories);
        PlayerPrefs.SetString("DinnerEntryDate", DateTime.Today.ToString("d"));

        // Εκτύπωση των δεδομένων στην κονσόλα
        Debug.Log("Dinner Food Name: " + foodName);
        Debug.Log("Dinner Calories: " + calories);
        Debug.Log("Dinner Entry Date: " + DateTime.Today.ToString("d"));

        // Απενεργοποίηση των πεδίων εισόδου και του κουμπιού
        foodNameInput.interactable = false;
        caloriesInput.interactable = false;
        saveButton.gameObject.SetActive(false);
    }

}
