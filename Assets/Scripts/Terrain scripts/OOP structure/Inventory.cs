using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items;
    public float maximumWeight = 10.0f;
    public float totalWeight;

    void Awake()
    {
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

    public bool AddItem(Item item)
    {
        if (totalWeight + item.weight > maximumWeight)
        {
            return false;
        }
        else
        {
            items.Add(item);
           // InventoryUI.instance.Add(item);
            totalWeight += item.weight;
            return true;
        }
    }

    public void removeItem(Item item)
    {
        if (items.Remove(item))
        {
           // InventoryUI.instance.Remove(item);
            totalWeight -= item.weight;
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
      