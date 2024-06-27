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
    public GameObject xAxisLabelPrefab; // Prefab for X axis labels
    public GameObject yAxisLabelPrefab; // Prefab for Y axis labels
    public GameObject labelPrefab; // Prefab for labels (newly added)

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

        // Clear previous labels
        foreach (Transform child in graphContainer.transform)
        {
            if (child.name == "XAxisLabel" || child.name == "YAxisLabel" || child.name == "LegendLabel")
            {
                Destroy(child.gameObject);
            }
        }

        // Create Y axis labels
        int separatorCount = 10; // Number of intervals on Y axis
        for (int i = 0; i <= separatorCount; i++)
        {
            float normalizedValue = i * 1f / separatorCount;
            float yPosition = normalizedValue * graphHeight;
            CreateYAxisLabel(yPosition, (normalizedValue * yMaximum).ToString("0"));
        }

        for (int i = 0; i < calorieIntake.Length; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition1 = (calorieIntake[i] / yMaximum) * graphHeight;
            float yPosition2 = (caloriesBurned[i] / yMaximum) * graphHeight;

            CreateCircle(new Vector2(xPosition, yPosition1));
            CreateCircle(new Vector2(xPosition, yPosition2));

            lineRenderer1.SetPosition(i, new Vector3(xPosition, yPosition1, 0));
            lineRenderer2.SetPosition(i, new Vector3(xPosition, yPosition2, 0));

            CreateXAxisLabel(xPosition, (i + 1).ToString()); // Labeling days of the month
        }

        xAxisLabel.text = "Days of the Month";
        yAxisLabel.text = "Calories";

        // Create legend labels
        CreateLegendLabel(new Vector2(100, graphHeight + 30), "Calories Intake", Color.red);
        CreateLegendLabel(new Vector2(250, graphHeight + 30), "Calories Burned", Color.blue);
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

    private void CreateXAxisLabel(float xPosition, string label)
    {
        GameObject labelObject = Instantiate(xAxisLabelPrefab);
        labelObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = labelObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(xPosition, 0f); // Adjust Y offset as needed
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        labelObject.GetComponent<TextMeshProUGUI>().text = label;
        labelObject.name = "XAxisLabel";
    }

    private void CreateYAxisLabel(float yPosition, string label)
    {
        GameObject labelObject = Instantiate(yAxisLabelPrefab);
        labelObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = labelObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0f, yPosition); // Adjust X offset as needed
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        labelObject.GetComponent<TextMeshProUGUI>().text = label;
        labelObject.name = "YAxisLabel";
    }

    private void CreateLegendLabel(Vector2 position, string labelText, Color color)
    {
        GameObject labelObject = Instantiate(labelPrefab);
        labelObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = labelObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position; // Adjust the position as needed
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        TextMeshProUGUI textMesh = labelObject.GetComponent<TextMeshProUGUI>();
        textMesh.text = labelText;
        textMesh.color = color;
        labelObject.name = "LegendLabel";
    }
}
