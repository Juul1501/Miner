using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Inventory : Data
{
    public static Inventory instance;
    public JsonLoader jsonLoader;

    public List<Item> items;
    

    void Awake()
    {
        jsonLoader = new JsonLoader();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item);
    }

    public void removeItem(Item item)
    {
        if (items.Remove(item))
        {
           // InventoryUI.instance.Remove(item);
        }
    }

    public void removeByName(string name)
    {
        foreach (Item i in items)
        {
            if (i.name == name)
            {
                removeItem(i);
                break;
            }
        }
    }




}
      