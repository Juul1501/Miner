using System.IO;
using UnityEngine;

public class JsonLoader 
{

    public void SaveJson(Upgrades u, string filePath)
    {
        string jsonData = JsonUtility.ToJson(u, true);
        File.WriteAllText(Application.persistentDataPath + filePath, jsonData);

        Debug.Log("Saved json");
    }

    public Upgrades LoadJson(string filePath)
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + filePath);
        Upgrades passTrough;
        passTrough = new Upgrades();
        JsonUtility.FromJsonOverwrite(jsonData, passTrough);
        Debug.Log("Loaded json");

        return (passTrough);
    }

    public void ClearJson (string filePath)
    {
        File.WriteAllText(Application.persistentDataPath + filePath, null);
        Debug.Log("Cleared Json");
    }
}
