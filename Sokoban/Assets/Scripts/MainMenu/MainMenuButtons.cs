using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void Play()
    {
        GameConfiguration.CustomLevel = false;
        GameConfiguration.actualLevel = 1;
        GameConfiguration.levelName = "level" + GameConfiguration.actualLevel;
        SceneManager.LoadScene("Level");
    }
    public void PlayCustom()
    {
        transform.Find("SelectLevelModal").gameObject.SetActive(true);
    }
    public void LevelEditor()
    {
        SceneManager.LoadScene("LevelEditor");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
