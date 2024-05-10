using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GymTracker : MonoBehaviour
{
    public TMP_Text date;
    public Button tickButton;

    private bool hasWorkedOutToday = false;

    void Start()
    {
        // Get today's date
        string today = System.DateTime.Today.ToString("dd/MM/yyyy");

        // Display today's date on the Text UI
        date.text = "Today's date is: " + today;

        // Add listener to the tick button
        tickButton.onClick.AddListener(OnTickButtonClick);
    }

    void OnTickButtonClick()
    {
        // If the user clicks the tick button, toggle the value of hasWorkedOutToday
        hasWorkedOutToday = !hasWorkedOutToday;

        if (hasWorkedOutToday)
        {
            Debug.Log("You worked out today!");
        }
        else
        {
            Debug.Log("You didn't work out today.");
        }
    }
}



