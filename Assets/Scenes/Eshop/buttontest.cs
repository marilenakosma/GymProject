using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    void OnButtonClick()
    {
        Debug.Log("Increment button clicked");
    }
}

