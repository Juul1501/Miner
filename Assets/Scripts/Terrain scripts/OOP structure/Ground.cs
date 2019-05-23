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
        depthLevel = this.depthLevel;
        toughNess = this.toughNess;
        groundObject = this.groundObject;
        Debug.Log(groundObject);
        mineable = this.mineable;
        position = this.position;
    }



}
