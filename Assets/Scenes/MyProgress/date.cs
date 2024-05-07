using System;
using UnityEngine;
using UnityEngine.UI;

public class GymTracker : MonoBehaviour
{
    public Text dateText;
    public Button tickButton;

    private bool hasWorkedOutToday = false;

    void Start()
    {
        // Get today's date
        DateTime today = DateTime.Today;

        // Display today's date on the Text UI
        dateText.text = "Today's date is: " + today.ToString("dd/MM/yyyy");

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