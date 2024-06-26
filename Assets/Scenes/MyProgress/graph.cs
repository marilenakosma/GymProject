using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalorieGraph : MonoBehaviour
{
    public RectTransform graphContainer;
    public Sprite circleSprite;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    public TextMeshProUGUI xAxisLabel;
    public TextMeshProUGUI yAxisLabel;

    private void Start()
    {
        // Example data
        int[] calorieIntake = new int[] { 2000, 1800, 2200, 2400, 2100, 1900, 2300, 2500, 2200, 2100, 2000, 1950, 2050, 2100, 2200, 2300, 2100, 2200, 2300, 2400, 2500, 2300, 2200, 2000, 2100, 2300, 2400, 2500, 2200, 2300 };
        int[] caloriesBurned = new int[] { 300, 500, 400, 600, 350, 400, 500, 600, 550, 500, 450, 600, 700, 650, 550, 600, 500, 650, 700, 800, 750, 700, 650, 600, 550, 700, 800, 750, 700, 650 };

        ShowGraph(calorieIntake, caloriesBurned);
    }

    private void ShowGraph(int[] calorieIntake, int[] caloriesBurned)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float yMaximum = 3000f; // Adjust according to your data range
        float xSize = graphWidth / (calorieIntake.Length + 1);

        lineRenderer1.positionCount = calorieIntake.Length;
        lineRenderer2.positionCount = caloriesBurned.Length;

        for (int i = 0; i < calorieIntake.Length; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition1 = (calorieIntake[i] / yMaximum) * graphHeight;
            float yPosition2 = (caloriesBurned[i] / yMaximum) * graphHeight;

            CreateCircle(new Vector2(xPosition, yPosition1));
            CreateCircle(new Vector2(xPosition, yPosition2));

            lineRenderer1.SetPosition(i, new Vector3(xPosition, yPosition1));
            lineRenderer2.SetPosition(i, new Vector3(xPosition, yPosition2));

            xAxisLabel.text = "Days of the Month";
            yAxisLabel.text = "Calories";
        }
    }

    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }
}
