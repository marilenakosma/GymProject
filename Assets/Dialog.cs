using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dialog : MonoBehaviour
{
    public Text chatText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Enable the chat text and set its position near the chat icon
        chatText.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Disable the chat text when the mouse exits the chat icon
        chatText.enabled = false;
    }

}
