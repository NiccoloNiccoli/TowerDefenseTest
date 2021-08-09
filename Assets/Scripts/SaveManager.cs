using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class SaveManager {
    public static string directory = "/SaveData/";
    public static string filename = "saveFile.txt";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + filename, json);

    }
    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + filename;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return so;
    }
}
[System.Serializable]
public class SaveObject
{
    public int nLevelUnlocked;
    public int nCharacterUnlocked;
}

