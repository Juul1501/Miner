using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece : Item
{
    public int ID;
    public UnityEngine.GameObject artifactPieceObject;



    public ArtifactPiece (string name, int weight, int ID, UnityEngine.GameObject artifactPieceObject) : base(name, weight)
    {
        ID = this.ID;
        artifactPieceObject = this.artifactPieceObject;
    }
}

