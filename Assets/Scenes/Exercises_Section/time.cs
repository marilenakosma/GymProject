using UnityEngine;
using TMPro;

public class PageTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Αναφορά στο TextMeshProUGUI για την εμφάνιση του χρόνου
    private float startTime;
    private float elapsedTime;
    private bool isTiming;
    public string pageIdentifier; // Μοναδικός προσδιοριστής για κάθε σελίδα

    void OnEnable()
    {
        // Ξεκινά ο χρονομετρητής
        startTime = Time.time;
        isTiming = true;
    }

    void OnDisable()
    {
        // Σταματά ο χρονομετρητής και αποθηκεύεται ο χρόνος με τον μοναδικό προσδιοριστή
        elapsedTime = Time.time - startTime;
        PlayerPrefs.SetFloat(pageIdentifier, elapsedTime);
        PlayerPrefs.Save();
        isTiming = false;
        Debug.Log($"Elapsed Time for {pageIdentifier}: " + elapsedTime + " seconds");
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
