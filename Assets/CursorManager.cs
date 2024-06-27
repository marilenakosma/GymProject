using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    public RectTransform cursorTransform;
    public float moveSpeed = 500f; // Ταχύτητα κίνησης του κέρσορα

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Διατηρεί το αντικείμενο όταν φορτώνει νέα σκηνή
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

        // Διατηρήστε τον κέρσορα εντός των ορίων της οθόνης
        Vector2 pos = cursorTransform.anchoredPosition;
        pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height);
        cursorTransform.anchoredPosition = pos;
    }
}
