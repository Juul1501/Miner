using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public Money money;

    private static MoneyManager instance = null;
    public static MoneyManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        money = new Money(0);

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
