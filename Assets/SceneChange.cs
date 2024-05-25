using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    public void SelectCategory(int categoryIndex,int SceneID)
    {
        PlayerPrefs.SetInt("SelectedCategory", categoryIndex);
        MoveToScene(SceneID);
    }

}
