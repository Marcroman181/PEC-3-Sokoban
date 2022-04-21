using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor 
{
    private static Dictionary<BoxStatus, Color> BOX_COLOR_DICTIONARY = new Dictionary<BoxStatus, Color>()
    {
         {BoxStatus.EMPTY, new Color(0, 0.4f, 0.05f, 1)},
         {BoxStatus.PLAYER, new Color(1, 0.4f, 0.05f, 1)},
         {BoxStatus.TARGET, Color.red},
         {BoxStatus.WALL, new Color(0.06f, 1, 0, 1)},
         {BoxStatus.BOX, Color.blue}
    };

    public static Color GetBoxColor(BoxStatus boxStatus)
    {
        return BOX_COLOR_DICTIONARY[boxStatus];
    }

}
