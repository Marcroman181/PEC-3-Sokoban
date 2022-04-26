using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CellController : MonoBehaviour
{

    private Box Box;
    private Image Image;

    // Start is called before the first frame update
    void Start()
    {
        int boxNumber = int.Parse(Regex.Replace(gameObject.name, "[^0-9]", ""));

        Box = new Box();  
        Box.positionY = boxNumber / 15;
        Box.positionX = boxNumber % 15;
        Box.boxStatus = BoxStatus.EMPTY;
        Image = gameObject.GetComponent<Image>();

        ColorizeImage();
    }

    private void ColorizeImage()
    {
        Image.color = BoxColor.GetBoxColor(Box.boxStatus);
    }

    public void ChangeBoxStatus()
    {
        Box.boxStatus = LevelEditor.BoxStatusSelected;
        ColorizeImage();
    }

    public Box GetBox()
    {
        return Box;
    }

}
