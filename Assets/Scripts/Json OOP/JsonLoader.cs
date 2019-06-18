using System.IO;
using UnityEngine;

public class JsonLoader 
{

    public void SaveJson(Data u, string filePath)
    {
        string jsonData = JsonUtility.ToJson(u, true);
        File.WriteAllText(Application.persistentDataPath + filePath, jsonData);

        Debug.Log("Saved json");
    }

    public Data LoadJson(Data dataType, string filePath)
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + filePath);
        JsonUtility.FromJsonOverwrite(jsonData, dataType);
        Debug.Log("Loaded json");

        return (dataType);
    }

    public void DeleteJson (string filePath)
    {
        File.Delete(Application.persistentDataPath + filePath);
        Debug.Log("Cleared Json");
    }
}
