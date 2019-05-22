using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground {
    public int depthLevel;
    public int toughNess;
    public bool mineable;

    public Vector2Int position;
    
    public UnityEngine.GameObject groundObject;



    public Ground (int depthLevel, int toughNess, UnityEngine.GameObject groundObject, bool mineable, Vector2Int position)
    {
        depthLevel = this.depthLevel;
        toughNess = this.toughNess;
        groundObject = this.groundObject;
        mineable = this.mineable;
        position = this.position;
    }



}
