using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    //upgrade Indicators 
    public GameObject[] maxFuelIndicator;
    public GameObject[] slideLengthIndicator;
    public GameObject[] moveSpeedIndicator;

    public GameObject[] upgradePanel;
    public int panelCounter;


    public Sprite[] speedSprites;
    public Sprite[] fuelSprites;

    public GameObject[] spriteItem;

    public Text moneyText;
    public Text upgradePriceText;

    public string upgradeSavepath;
    public Upgrades upgrades;
    public object castingObject;
    public JsonLoader jsonLoader;
    
    void Awake()
    {
        CheckPanels();

        //Instantiate or load Json File
        jsonLoader = new JsonLoader();
        if(System.IO.File.Exists(Application.persistentDataPath + upgradeSavepath)) 
        {
                Data d = jsonLoader.LoadJson(upgrades, upgradeSavepath);
                if (d is Upgrades)
                {
                    upgrades = (Upgrades)d;
                }

                Data m = jsonLoader.LoadJson(MoneyManager.Instance.money, "/money.cash");
                if (m is Money)
                {
                    MoneyManager.Instance.money = (Money)m;
                }
            
                

        } else {
            upgrades = new Upgrades();
            jsonLoader.SaveJson(upgrades,upgradeSavepath);
            Debug.Log("created new json");
        }

        upgrades.MaxFuelUpgrade.Price = 150;
        upgrades.MoveSpeedUpgrade.Price = 200;
        upgrades.SlideLengthUpgrade.Price = 100;
        upgradePriceText.text = "$ " + upgrades.MoveSpeedUpgrade.Price;


        InitiateIndicators();
        Debug.Log(MoneyManager.Instance.money.Amount);
    }

    void Update() {
        moneyText.text = "" + MoneyManager.Instance.money.Amount;
        CheckPanels();
    }


    public void CheckPanels()
    {
        if  (panelCounter == 0)
        {
            upgradePanel[0].SetActive(true);
            upgradePriceText.text = "$ " + upgrades.MoveSpeedUpgrade.Price;
        } else {
            upgradePanel[0].SetActive(false);
        }

        if  (panelCounter == 1)
        {
            upgradePanel[1].SetActive(true);
            upgradePriceText.text = "$ " + upgrades.FuelSpeedUpgrade.Price;
        } else {
            upgradePanel[1].SetActive(false);
        }
    }

    public void SwitchPanelOnPress(string direction)
    {
        if (direction == "right" && panelCounter < 2)
        {
            panelCounter ++;
        } else if (direction == "left" && panelCounter > 0) {
            panelCounter --;
        }
        CheckPanels();
        InitiateIndicators();
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
       if(upgradeType.level < 5 && MoneyManager.Instance.money.Amount >= upgradeType.Price)
       {
            upgradeType.Value += upgradeValue;
            upgradeType.level += upgradeLevel;
            MoneyManager.Instance.money.Amount -= upgradeType.Price;
            jsonLoader.SaveJson(upgrades,upgradeSavepath);
            jsonLoader.SaveJson(MoneyManager.Instance.money,"/money.cash");
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
                spriteItem[0].GetComponent<Image>().sprite = fuelSprites[i];
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
                spriteItem[1].GetComponent<Image>().sprite = speedSprites[i];
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
