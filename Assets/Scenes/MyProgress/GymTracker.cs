using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GymTracker : MonoBehaviour
{
    public TMP_Text dayText;
    public TMP_Text monthText;
    public TMP_Text yearText;
    public Button tickButton;

    private bool hasWorkedOutToday = false;

    void Start()
    {
        // Get today's date
        System.DateTime today = System.DateTime.Today;

        // Display today's date on the Text UI
        dayText.text = today.Day.ToString();
        monthText.text = GetEnglishMonthName(today.Month); // Get month name in English
        yearText.text = today.Year.ToString();

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

    // Function to get English month name from month number
    string GetEnglishMonthName(int monthNumber)
    {
        return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthNumber);
    }
}
