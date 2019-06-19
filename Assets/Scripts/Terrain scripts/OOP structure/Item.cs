using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Item
{
    public string name;

    public Item(string name)
    {
        this.name = name;
    }
}

