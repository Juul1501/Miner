using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    //upgrade Indicators 
    public GameObject[] maxFuelIndicator;
    public GameObject[] slideLengthIndicator;
    public GameObject[] moveSpeedIndicator;

    public Text moneyText;

    public string upgradeSavepath;
    public Upgrades upgrades;
    public object castingObject;
    public JsonLoader jsonLoader;
    
    void Awake()
    {
        
        moneyText.text = "monni " + MoneyManager.Money.ToString();
        //Instantiate or load Json File
        jsonLoader = new JsonLoader();
        if(System.IO.File.Exists(Application.persistentDataPath + upgradeSavepath)) 
        {
                Data d = jsonLoader.LoadJson(upgrades, upgradeSavepath);
                if (d is Upgrades)
                {
                    upgrades = (Upgrades)d;
                }

        } else {
            upgrades = new Upgrades();
            jsonLoader.SaveJson(upgrades,upgradeSavepath);
            Debug.Log("created new json");
        }

        InitiateIndicators();
       
    }
    public void Update()
    {
        moneyText.text = "monni " + MoneyManager.Money.ToString();
    }

    public void SpeedButtonPress()
    {
        buyUpgrade(upgrades.MoveSpeedUpgrade, 0.02f, 1);
        InitiateIndicators();
    }

    public void FuelButtonPress()
    {
        buyUpgrade(upgrades.MaxFuelUpgrade, 30f, 1);
        InitiateIndicators();
    }

     public void SlideButtonPress()
    {
        buyUpgrade(upgrades.SlideLengthUpgrade, 1, 1);
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

    public void ResetUpgrades(){
        jsonLoader.DeleteJson(upgradeSavepath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

        slideLengthIndicator = GameObject.FindGameObjectsWithTag("slidelengthdots");
        for (int i = 0; i < slideLengthIndicator.Length; i++)
        {
            if(i < upgrades.SlideLengthUpgrade.level){
                slideLengthIndicator[i].GetComponent<Toggle>().isOn = true;
            } else {
                slideLengthIndicator[i].GetComponent<Toggle>().isOn = false;
            }
        }

        moveSpeedIndicator = GameObject.FindGameObjectsWithTag("movespeeddots");
        for (int i = 0; i < moveSpeedIndicator.Length; i++)
        {
            if(i < upgrades.MoveSpeedUpgrade.level){
                moveSpeedIndicator[i].GetComponent<Toggle>().isOn = true;
            } else {
                moveSpeedIndicator[i].GetComponent<Toggle>().isOn = false;
            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
