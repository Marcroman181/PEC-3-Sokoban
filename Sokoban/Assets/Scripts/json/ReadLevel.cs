using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadLevel
{

    private static string PATH_FILE = "Assets/Resources/Levels/";

    private static string FILE_EXTENSION = ".json";

    public static List<Box> Read(string nameLevel)
    {
        string path = PATH_FILE + nameLevel + FILE_EXTENSION;
        if (System.IO.File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Level Level = JsonUtility.FromJson<Level>(json);
            return Level.BoxList;
        }
        return null;
    }
}
