using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece
{
    public int ID;
    public UnityEngine.GameObject artifactPieceObject;



    public ArtifactPiece artifactPiece(int ID, UnityEngine.GameObject artifactPieceObject)
    {
        ID = this.ID;
        artifactPieceObject = this.artifactPieceObject;
    }
}

