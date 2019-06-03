using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece : Item
{
    public int ID;


    public ArtifactPiece (string name, int weight, int ID) : base(name)
    {
        this.ID = ID;
    }
}

