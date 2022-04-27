using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Canvas;
    private PlatformController[] platforms;
    private bool paused;
    private bool completed;
    

    // Start is called before the first frame update
    void Start()
    {
        platforms = FindObjectsOfType(typeof(PlatformController)) as PlatformController[];
        paused = false;
        completed = false;
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            completed = isGameCompleted();
            if (completed)
            {
                CompleteGame();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    ResetGame();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Pause();
                }
            }
        }
    }

    private bool isGameCompleted()
    {

        bool completed = true;
        for (int i = 0; platforms.Length > i; i++)
        {
            if (!platforms[i].pushed)
            {
                completed = false;
            };
        }

        return completed;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void Pause()
    {
        paused = !paused;
        Canvas.SetActive(paused);
        Canvas.transform.Find("PauseMenu").gameObject.SetActive(paused);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsPaused()
    {
        return paused;
    }

    private void CompleteGame()
    {
        Canvas.SetActive(true);
        Canvas.transform.Find("CompleteMenu").gameObject.SetActive(true);
        if (!GameConfiguration.CustomLevel)
        {
            Canvas.transform.Find("CompleteMenu").transform.Find("Text").GetComponent<Text>().text = "Level " + GameConfiguration.actualLevel + " Completed!";
        }
        if (!GameConfiguration.CustomLevel && GameConfiguration.actualLevel < 10)
        {
            Canvas.transform.Find("CompleteMenu").transform.Find("NextLevelButton").gameObject.SetActive(true);
        }
    }

    public void Nextlevel()
    {
        GameConfiguration.actualLevel++; 
        GameConfiguration.levelName = "level" + GameConfiguration.actualLevel;
        SceneManager.LoadScene("Level");
    }
}
