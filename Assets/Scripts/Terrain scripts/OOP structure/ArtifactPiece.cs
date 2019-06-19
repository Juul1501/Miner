
using UnityEngine;
using System;

[Serializable] 
public class ArtifactPiece : Item
{
    public int ID;
    //public Sprite artifactSprite;


    public ArtifactPiece (string name, int ID /* ,Sprite artifactSprite*/) : base(name)
    {
        this.ID = ID;
       // this.artifactSprite = artifactSprite;
    }
}

