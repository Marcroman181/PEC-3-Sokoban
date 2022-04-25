using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveModalController : MonoBehaviour
{
    private Dropdown Dropdown;

    // Start is called before the first frame update
    void Start()
    {
        Dropdown = transform.Find("Container").transform.Find("LevelsDropdown").GetComponent<Dropdown>();
        Dropdown.ClearOptions();

        foreach (string levelName in ReadLevel.AllCustomLevels())
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = levelName;
            Dropdown.options.Add(option);
        }
        Dropdown.value = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void Back() 
    {
        gameObject.SetActive(false);
    }
}
