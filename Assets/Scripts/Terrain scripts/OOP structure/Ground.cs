using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground {
    public int depthLevel;
    public int toughNess;
    public bool mineable;

    public Vector2Int position;
    
    public GameObject groundObject;

    public GroundType mytype;

    public Ground (int depthLevel, int toughNess, GameObject groundObject, bool mineable, Vector2Int position, GroundType mytype)
    {
        this.depthLevel = depthLevel;
        this.toughNess = toughNess;
        this.groundObject = groundObject;
        this.mineable = mineable;
        this.position = position;
        this.mytype = GroundType.ground;
    }


}
