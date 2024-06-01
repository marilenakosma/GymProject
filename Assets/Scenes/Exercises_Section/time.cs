using UnityEngine;
using TMPro;
using System;

public class PageTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Αναφορά στο TextMeshProUGUI για την εμφάνιση του χρόνου
    private float startTime;
    private bool isTiming;
    public string pageIdentifier; // Μοναδικός προσδιοριστής για κάθε σελίδα

    void OnEnable()
    {
        // Ελέγχουμε αν η ημερομηνία έχει αλλάξει
        string lastSavedDate = PlayerPrefs.GetString("LastSavedDate", DateTime.MinValue.ToString());
        DateTime lastDate = DateTime.Parse(lastSavedDate);
        DateTime currentDate = DateTime.Today;

        if (currentDate > lastDate)
        {
            // Αν η ημερομηνία έχει αλλάξει, ξεκινάμε από την αρχή
            startTime = Time.time;
            isTiming = true;
        }
        else
        {
            // Αν η ημερομηνία δεν έχει αλλάξει, χρησιμοποιούμε την προηγούμενη αποθηκευμένη τιμή
            startTime = Time.time - PlayerPrefs.GetFloat(pageIdentifier, 0);
            isTiming = true;
        }
    }

    void OnDisable()
    {
        if (isTiming)
        {
            // Σταματά ο χρονομετρητής και αποθηκεύεται ο χρόνος με τον μοναδικό προσδιοριστή
            float elapsedTime = Time.time - startTime;
            PlayerPrefs.SetFloat(pageIdentifier, elapsedTime);
            PlayerPrefs.SetString("LastSavedDate", DateTime.Today.ToString());
            PlayerPrefs.Save();
            isTiming = false;
            Debug.Log($"Elapsed Time for {pageIdentifier}: " + elapsedTime + " seconds");
        }
    }

    void Update()
    {
        if (isTiming)
        {
            // Υπολογίζει τον τρέχοντα χρόνο και τον εμφανίζει στο UI
            float currentTime = Time.time - startTime;
            timerText.text = currentTime.ToString("F2") + " seconds";
        }
    }
}
