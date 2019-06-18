using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    //upgrade Indicators 
    public GameObject[] maxFuelIndicator;


    public string upgradeSavepath;
    public Upgrades upgrades;
    public JsonLoader jsonLoader;
    
    void Awake()
    {
        
        //Instantiate or load Json File
        jsonLoader = new JsonLoader();
        if(System.IO.File.Exists(Application.persistentDataPath + upgradeSavepath)) 
        {
            upgrades = jsonLoader.LoadJson(upgradeSavepath);
        } else {
            upgrades = new Upgrades();
            jsonLoader.SaveJson(upgrades,upgradeSavepath);
            Debug.Log("created new json");
        }

        InitiateIndicators();
       
    }

    public void OnButtonPress()
    {
        buyUpgrade(upgrades.MaxFuelUpgrade, 20f, 1);
        InitiateIndicators();
    }
    
    public void buyUpgrade (Upgrade upgradeType, float upgradeValue, int upgradeLevel)
    {
       if(upgradeType.level < 5)
       {
            upgradeType.Value += upgradeValue;
            upgradeType.level += upgradeLevel;
            jsonLoader.SaveJson(upgrades,upgradeSavepath);
       }
    }

    public void ClearUpgrades(){
        jsonLoader.ClearJson(upgradeSavepath);
    }

    public void InitiateIndicators()
    {
        //max fuel initiator
        maxFuelIndicator = GameObject.FindGameObjectsWithTag("maxfueldots");
        for (int i = 0; i < maxFuelIndicator.Length; i++)
        {
            if(i < upgrades.MaxFuelUpgrade.level){
                maxFuelIndicator[i].GetComponent<Toggle>().isOn = true;
            } else {
                maxFuelIndicator[i].GetComponent<Toggle>().isOn = false;
            }
        }
    }
}
