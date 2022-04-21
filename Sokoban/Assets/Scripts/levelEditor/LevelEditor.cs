using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditor : MonoBehaviour
{

    public static BoxStatus BoxStatusSelected = BoxStatus.WALL;

    private CellController[] cells;
    private SaveLevel SaveLevel;

    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.Find("Grid").transform.GetComponentsInChildren<CellController>();
        SaveLevel = new SaveLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CreateLevel()
    {
        Level level = new Level();
        List<Box> boxList = new List<Box>();
        for(int i = 0; cells.Length > i; i++)
        {
            boxList.Add(cells[i].GetBox());
        }
        level.BoxList = boxList;
        SaveLevel.Save("name", level);
    }
}
