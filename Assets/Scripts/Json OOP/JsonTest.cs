using System.IO;
using UnityEngine;

public class JsonTest : MonoBehaviour
{

    public Upgrades testUp;
    public Upgrades testinput;

    private void Awake()
    {
        testinput.MaxFuelUpgrade.Value = 50f;
        SaveJson(testinput, "/joden.mining");
        testUp =  LoadJson("/joden.mining");
    }

    private void SaveJson(Upgrades u, string savePath)
    {
        string jsonData = JsonUtility.ToJson(u, true);
        File.WriteAllText(Application.persistentDataPath + savePath, jsonData);

        Debug.Log("Saved json");
    }

    private Upgrades LoadJson(string loadPath)
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + loadPath);
        Upgrades passTrough;
        passTrough = new Upgrades();
        JsonUtility.FromJsonOverwrite(jsonData, passTrough);
        Debug.Log("Loaded json");

        return (passTrough);


    }
}
