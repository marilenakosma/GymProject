using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BreakfastEntry : MonoBehaviour
{
    public TMP_InputField foodNameInput;
    public TMP_InputField caloriesInput;
    public Button saveButton;

    void Start()
    {
        // Έλεγχος αν υπάρχουν ήδη αποθηκευμένα δεδομένα για την τρέχουσα ημερομηνία
        string savedDate = PlayerPrefs.GetString("BreakfastEntryDate", "");

        if (savedDate == DateTime.Today.ToString())
        {
            // Αν υπάρχουν δεδομένα για την τρέχουσα ημερομηνία, απενεργοποιούμε τα πεδία εισόδου και το κουμπί
            foodNameInput.interactable = false;
            caloriesInput.interactable = false;
            saveButton.gameObject.SetActive(false);

            // Εμφάνιση των αποθηκευμένων δεδομένων στα πεδία εισόδου
            string savedFoodName = PlayerPrefs.GetString("BreakfastFoodName", "No data");
            float savedCalories = PlayerPrefs.GetFloat("BreakfastCalories", 0f);
            foodNameInput.text = savedFoodName;
            caloriesInput.text = savedCalories.ToString();

            // Εκτύπωση των αποθηκευμένων δεδομένων στην κονσόλα για επιβεβαίωση
            Debug.Log("Already saved data for today:");
            Debug.Log("Breakfast Food Name: " + savedFoodName);
            Debug.Log("Breakfast Calories: " + savedCalories);
            Debug.Log("Breakfast Entry Date: " + savedDate);
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

        // Αποθηκεύουμε τα δεδομένα για το πρωινό μαζί με την σημερινή ημερομηνία
        PlayerPrefs.SetString("BreakfastFoodName", foodName);
        PlayerPrefs.SetFloat("BreakfastCalories", calories);
        PlayerPrefs.SetString("BreakfastEntryDate", DateTime.Today.ToString());

        // Εκτύπωση των δεδομένων στην κονσόλα
        Debug.Log("Breakfast Food Name: " + foodName);
        Debug.Log("Breakfast Calories: " + calories);
        Debug.Log("Breakfast Entry Date: " + DateTime.Today.ToString());

        // Απενεργοποίηση των πεδίων εισόδου και του κουμπιού
        foodNameInput.interactable = false;
        caloriesInput.interactable = false;
        saveButton.gameObject.SetActive(false);
    }


}
