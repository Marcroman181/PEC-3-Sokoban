using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadLevel
{

    private static string PATH_FILE = "StandardLevels/";

    private static string FILE_EXTENSION = ".json";
    private static string FILE_META_EXTENSION = ".json.meta";

    public static List<Box> Read()
    {
       string path = PATH_FILE + GameConfiguration.levelName;
       TextAsset txtAsset = (TextAsset)Resources.Load(path, typeof(TextAsset));
       Level Level = JsonUtility.FromJson<Level>(txtAsset.text);
       return Level.BoxList;
    }
    public static List<Box> ReadCustom()
    {
        string path = Application.dataPath + "/" + GameConfiguration.levelName + FILE_EXTENSION;
        if (System.IO.File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Level Level = JsonUtility.FromJson<Level>(json);
            return Level.BoxList;
        }
        return null;
    }

    public static List<string> AllCustomLevels()
    {
        List<string> files = new List<string>();
        string path = Application.dataPath + "/";
        foreach (string file in System.IO.Directory.GetFiles(path))
        {
            if (file.Contains(FILE_EXTENSION) && !file.Contains(FILE_META_EXTENSION))
            {
                files.Add(file.Replace(path, "").Split('.')[0]);
            }
        }
        return files;
    }
}
