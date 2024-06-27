using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomCursor : MonoBehaviour
{
    public RectTransform cursorTransform;
    public float moveSpeed = 500f; // Ταχύτητα κίνησης του κέρσορα

    private void Start()
    {
        // Κρύψτε τον κανονικό κέρσορα του συστήματος
        Cursor.visible = false;
    }

    private void Update()
    {
        // Λάβετε την είσοδο από τα βέλη του πληκτρολογίου
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Μετακινήστε τον κέρσορα
        cursorTransform.anchoredPosition += new Vector2(moveX, moveY);

        // Ανίχνευση κλικ στο Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ClickUIElementUnderCursor();
        }
    }

    private void ClickUIElementUnderCursor()
    {
        Vector2 cursorPos = cursorTransform.anchoredPosition;

        // Μετατροπή της θέσης του κέρσορα σε συντεταγμένες οθόνης
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, cursorPos);

        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = screenPos
        };

        // Λάβετε τα αντικείμενα UI κάτω από τον κέρσορα
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        // Αν υπάρχει ένα κουμπί κάτω από τον κέρσορα, κάντε κλικ σε αυτό
        foreach (var result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
                break;
            }
        }
    }
}
