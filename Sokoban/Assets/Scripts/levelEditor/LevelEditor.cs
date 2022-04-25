using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEditor : MonoBehaviour
{

    public static BoxStatus BoxStatusSelected = BoxStatus.EMPTY;
    public GameObject ErrorModal;
    public GameObject SaveModal;

    private CellController[] cells;
    private SaveLevel SaveLevel;

    private Image EmptyButtonImage;
    private Image WallButtonImage;
    private Image PlayerButtonImage;
    private Image TargetButtonImage;
    private Image BoxButtonImage;
    private Level Level;

    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.Find("Grid").transform.GetComponentsInChildren<CellController>();
        SaveLevel = new SaveLevel();
        EmptyButtonImage = GameObject.Find("EmptyBG").GetComponent<Image>();
        BoxButtonImage = GameObject.Find("BoxBG").GetComponent<Image>();
        WallButtonImage = GameObject.Find("WallBG").GetComponent<Image>();
        PlayerButtonImage = GameObject.Find("PlayerBG").GetComponent<Image>();
        TargetButtonImage = GameObject.Find("TargetBG").GetComponent<Image>();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CreateLevel()
    {
        Level level = new Level();
        List<Box> boxList = new List<Box>();

        int numPlayerBoxes = 0;
        int numTargetBoxes = 0;
        int numBoxBoxes = 0;

        for (int i = 0; cells.Length > i; i++)
        {
            Box box = cells[i].GetBox();
            if(box.boxStatus == BoxStatus.PLAYER)
            {
                numPlayerBoxes++;
            }
            if (box.boxStatus == BoxStatus.BOX)
            {
                numBoxBoxes++;
            }
            if (box.boxStatus == BoxStatus.TARGET)
            {
                numTargetBoxes++;
            }

            boxList.Add(cells[i].GetBox());
        }
        level.BoxList = boxList;
        if (numPlayerBoxes == 0 || numPlayerBoxes > 1)
        {
            ShowError("The number of the players has to be 1.");
        }
        else if (numTargetBoxes != numBoxBoxes)
        {
            ShowError("The number of the boxes and targets are different.");
        }
        else if (numTargetBoxes == 0 || numBoxBoxes == 0)
        {
            ShowError("The number of the boxes and targets have to be greater than 0.");
        }
        else
        {
            Level = level;
            ShowSaveModal();
        }
    }

    public void Save()
    {
        //save level
        bool created = false;
        string name = SaveModal.transform.Find("Container").transform.Find("LevelNameContainer").transform.Find("LevelNameInput").transform.Find("Text").GetComponent<Text>().text;
        if(name == null || name == "")
        {
            ShowError("The name of the level can not be empty.");
        } else
        {
            created = SaveLevel.Save(name, Level);
            if (!created)
            {
                ShowError("The name of the level already exists.");
            } else
            {
                SuccesfullSavedMessage();
            }
        }
    }

    private void ShowSaveModal()
    {
        SaveModal.SetActive(true);
        SaveModal.transform.Find("Container").transform.Find("LevelNameContainer").gameObject.SetActive(true);
    }

    private void SuccesfullSavedMessage()
    {
        SaveModal.transform.Find("Container").transform.Find("LevelNameContainer").gameObject.SetActive(false);
        SaveModal.transform.Find("Container").transform.Find("Message").gameObject.SetActive(true);
    }

    public void CloseSaveModal()
    {
        SaveModal.transform.Find("Container").transform.Find("LevelNameContainer").gameObject.SetActive(false);
        SaveModal.transform.Find("Container").transform.Find("Message").gameObject.SetActive(false);
        SaveModal.SetActive(false);

    }

    private void ShowError(string message)
    {
        ErrorModal.SetActive(true);
        ErrorModal.transform.Find("Container").transform.Find("Message").GetComponent<Text>().text = message;
    }

    public void CloseErrorModal()
    {
        ErrorModal.SetActive(false);
    }

    private void ResetSelecteds()
    {
        Color color = new Color(1, 1, 1, 0);
        EmptyButtonImage.color = color;
        WallButtonImage.color = color;
        PlayerButtonImage.color = color;
        TargetButtonImage.color = color;
        BoxButtonImage.color = color;

    }

    public void SelectEmptyCell()
    {
        ResetSelecteds();
        BoxStatusSelected = BoxStatus.EMPTY;
        EmptyButtonImage.color = new Color(1, 1, 1, 1);
    }

    public void SelectWallCell()
    {
        ResetSelecteds();
        BoxStatusSelected = BoxStatus.WALL;
        WallButtonImage.color = new Color(1, 1, 1, 1);
    }

    public void SelectPlayerCell()
    {
        ResetSelecteds();
        BoxStatusSelected = BoxStatus.PLAYER;
        PlayerButtonImage.color = new Color(1, 1, 1, 1);
    }

    public void SelectBoxCell()
    {
        ResetSelecteds();
        BoxStatusSelected = BoxStatus.BOX;
        BoxButtonImage.color = new Color(1, 1, 1, 1);
    }

    public void SelectTargetCell()
    {
        ResetSelecteds();
        BoxStatusSelected = BoxStatus.TARGET;
        TargetButtonImage.color = new Color(1, 1, 1, 1);
    }
}
