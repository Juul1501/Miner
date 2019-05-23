using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground {
    public int depthLevel;
    public int toughNess;
    public bool mineable;

    public Vector2Int position;
    
    public GameObject groundObject;



    public Ground (int depthLevel, int toughNess, GameObject groundObject, bool mineable, Vector2Int position)
    {
        this.depthLevel = depthLevel;
        this.toughNess = toughNess;
        this.groundObject = groundObject;
        this.mineable = mineable;
        this.position = position;
    }
}
