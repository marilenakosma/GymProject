using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
  [SerializeField] RectTransform UIHandleRectTransform;
  [SerializeField] Color BackgroundActiveColor;
  [SerializeField] Color HandleActiveColor;

    Image backgroundImage, handleImage;

   Color BackgroundDefaultColor, handleDefaultColor;
   Toggle switchtoggle;
   Vector2 handlePosition;

   void Awake() {
    switchtoggle = GetComponent <Toggle> ();

    handlePosition = UIHandleRectTransform.anchoredPosition;
    backgroundImage = UIHandleRectTransform.parent.GetComponent <Image> ();
    handleImage = UIHandleRectTransform. GetComponent <Image> ();
    
    BackgroundDefaultColor = backgroundImage.color;
    handleDefaultColor = handleImage.color;
    
    switchtoggle.onValueChanged.AddListener(OnSwitch);

    if(switchtoggle.isOn)
     OnSwitch(true);
   }

   void OnSwitch(bool on) {
        if (on)
        {
            UIHandleRectTransform.anchoredPosition = handlePosition * -1;
            backgroundImage.color= BackgroundActiveColor;
            handleImage.color = HandleActiveColor;
        }
        else
        {
            UIHandleRectTransform.anchoredPosition = handlePosition;
            backgroundImage.color= BackgroundDefaultColor;
            handleImage.color = handleDefaultColor;
        }
   }

   void OnDestroy() {
       // switchtoggle.onValueChanged.RemoveListener(OnSwitch);
   }
}
