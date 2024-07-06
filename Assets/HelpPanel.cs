using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpManager : MonoBehaviour
{
    public GameObject helpPanel;
    public Button helpButton;
    public Button closeButton;

    void Start()
    {
        helpButton.onClick.AddListener(OpenHelp);
        closeButton.onClick.AddListener(CloseHelp);
        helpPanel.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    void OpenHelp()
    {
        helpPanel.SetActive(true);
        helpButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    void CloseHelp()
    {
        helpPanel.SetActive(false);
        helpButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
    }
}

