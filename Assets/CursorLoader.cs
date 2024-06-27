using UnityEngine;

public class CursorLoader : MonoBehaviour
{
    public GameObject cursorPrefab;

    private void Start()
    {
        if (CursorManager.Instance == null)
        {
            Instantiate(cursorPrefab);
        }
    }
}
