using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DisplayAllTimes : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Αναφορά στο TextMeshProUGUI για την εμφάνιση των χρόνων
    public List<string> pageIdentifiers; // Λίστα με τους προσδιοριστές σελίδων

    void Start()
    {
        string allTimesText = "";
        foreach (string pageId in pageIdentifiers)
        {
            float elapsedTime = PlayerPrefs.GetFloat(pageId, 0);
            allTimesText += $"{pageId}: {elapsedTime.ToString("F2")} seconds\n";
            Debug.Log($"Saved Elapsed Time for {pageId}: {elapsedTime} seconds");
        }
        displayText.text = allTimesText;
    }
}
