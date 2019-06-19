using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] 
public class ArtifactPiece : Item
{
    public int ID;


    public ArtifactPiece (string name, int ID) : base(name)
    {
        this.ID = ID;
    }
}

