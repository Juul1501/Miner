﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public int pieces;
    public int snappedPieces;
    public JsonLoader jsonLoader;
    public void onsnap()
    {

        if(System.IO.File.Exists(Application.persistentDataPath + "/money.cash")) 
        {

                Data m = jsonLoader.LoadJson(MoneyManager.Instance.money, "/money.cash");
                if (m is Money)
                {
                    MoneyManager.Instance.money = (Money)m;
                }
        } else {
            MoneyManager.Instance.money = new Money(0);
            jsonLoader.SaveJson(MoneyManager.Instance.money,"/money.cash");
            Debug.Log("created new json");
        }

        snappedPieces++;
        if(pieces <= snappedPieces)
        {
            jsonLoader = new JsonLoader();
            Data m = jsonLoader.LoadJson(MoneyManager.Instance.money ,"/money.cash");
                if (m is Money)
                {
                    MoneyManager.Instance.money = (Money)m;
                }

            //MoneyManager.Instance.money.Amount = 

            Debug.Log("jeeejj je hebt de puzzle af");
            MoneyManager.Instance.money.Amount += 100;
            jsonLoader.SaveJson(MoneyManager.Instance.money, "/money.cash");
            Debug.Log(MoneyManager.Instance.money.Amount);

        }
    }
}
