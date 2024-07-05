using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform UIHandleRectTransform;

    Image backgroundImage, handleImage;

    Toggle switchtoggle;
    Vector2 handlePosition;

    void Awake()
    {
        switchtoggle = GetComponent<Toggle>();

        handlePosition = UIHandleRectTransform.anchoredPosition;
        backgroundImage = UIHandleRectTransform.parent.GetComponent<Image>();
        handleImage = UIHandleRectTransform.GetComponent<Image>();

        switchtoggle.onValueChanged.AddListener(OnSwitch);

        if (switchtoggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        Debug.Log($"Switch is {(on ? "On" : "Off")}");
        Debug.Log($"Initial Handle Position: {handlePosition}");

        
        if (on)
        {
            UIHandleRectTransform.anchoredPosition = handlePosition * -1;
            backgroundImage.color = Color.cyan;
            handleImage.color = Color.white;
        }
        else
        {
            UIHandleRectTransform.anchoredPosition = handlePosition;
            backgroundImage.color = Color.white;
            handleImage.color = Color.cyan;
        }
        
        Debug.Log($"Updated Handle Position: {UIHandleRectTransform.anchoredPosition}");
    }

    void OnDestroy()
    {
        switchtoggle.onValueChanged.RemoveListener(OnSwitch);
    }
}



