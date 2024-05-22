using UnityEngine;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    public int categoryIndex; 

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        
        int faqSceneID = 15; 
        FindObjectOfType<SceneChange>().SelectCategory(categoryIndex, faqSceneID);
    }
}

