using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Canvas;
    private PlatformController[] platforms;
    private bool paused;
    

    // Start is called before the first frame update
    void Start()
    {
        platforms = FindObjectsOfType(typeof(PlatformController)) as PlatformController[];
        paused = false;
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameCompleted())
        {
            Debug.Log("Completed");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
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
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsPaused()
    {
        return paused;
    }
}
