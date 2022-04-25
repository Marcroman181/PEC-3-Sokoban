﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class SaveLevel
{
    private static string PATH_FILE = "Assets/Resources/Levels/";

    private static string FILE_EXTENSION = ".json";

    public static bool Save(string nameLevel, Level level)
    {
        string path = PATH_FILE + nameLevel + FILE_EXTENSION;
        if (!System.IO.File.Exists(path))
        {
            File.WriteAllText(path, JsonUtility.ToJson(level));
            return true;
        }
        return false;
    }
}
