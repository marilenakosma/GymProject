using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FoodEntry : MonoBehaviour
{
    public TMP_InputField foodNameInput;
    public TMP_InputField caloriesInput;
    public Button saveButton;

    void Start()
    {
        saveButton.onClick.AddListener(SaveFoodEntry);
    }

    public void SaveFoodEntry()
    {
        // Παίρνουμε τα δεδομένα από τα input fields
        string foodName = foodNameInput.text;
        float calories = float.Parse(caloriesInput.text);

        // Αποθηκεύουμε τα δεδομένα μαζί με την σημερινή ημερομηνία
        PlayerPrefs.SetString("FoodName", foodName);
        PlayerPrefs.SetFloat("Calories", calories);
        PlayerPrefs.SetString("EntryDate", DateTime.Today.ToString());

        // Εκτύπωση των δεδομένων στην κονσόλα
        Debug.Log("Food Name: " + foodName);
        Debug.Log("Calories: " + calories);
        Debug.Log("Entry Date: " + DateTime.Today.ToString());

        // Απενεργοποίηση των πεδίων εισόδου και του κουμπιού
        foodNameInput.interactable = false;
        caloriesInput.interactable = false;
        saveButton.gameObject.SetActive(false);
    }
}
