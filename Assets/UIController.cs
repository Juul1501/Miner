using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject itemPrefab;

    public void createItems(){
        foreach(Item i in Inventory.instance.items)
        {
            GameObject go = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, transform);
        }
    }

    void Start(){
        createItems();
    }
}
