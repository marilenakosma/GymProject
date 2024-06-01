using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class DisplayAllTimes : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Αναφορά στο TextMeshProUGUI για την εμφάνιση των χρόνων
    public List<string> pageIdentifiers; // Λίστα με τους προσδιοριστές σελίδων

    void Start()
    {
        // Έλεγχος αν η μέρα έχει αλλάξει
        string lastSavedDate = PlayerPrefs.GetString("LastSavedDate", DateTime.MinValue.ToString());
        DateTime lastDate = DateTime.Parse(lastSavedDate);
        DateTime currentDate = DateTime.Today;

        // Αν η μέρα έχει αλλάξει, μηδενίζουμε τους χρόνους
        if (currentDate > lastDate)
        {
            foreach (string pageId in pageIdentifiers)
            {
                PlayerPrefs.SetFloat(pageId, 0);
            }
            PlayerPrefs.SetString("LastSavedDate", currentDate.ToString());
            PlayerPrefs.Save();
        }

        // Εμφάνιση των χρόνων
        string allTimesText = "";
        foreach (string pageId in pageIdentifiers)
        {
            float elapsedTime = PlayerPrefs.GetFloat(pageId, 0);
            allTimesText += $"{pageId}: {elapsedTime.ToString("F2")} seconds\n";
            //Debug.Log($"Saved Elapsed Time for {pageId}: {elapsedTime} seconds");
        }
        displayText.text = allTimesText;
    }
}
