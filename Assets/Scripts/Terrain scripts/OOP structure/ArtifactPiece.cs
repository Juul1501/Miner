using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPiece
{
    public int ID;
    public UnityEngine.GameObject artifactPieceObject;



    public ArtifactPiece (int ID, GameObject artifactPieceObject)
    {
        this.ID = ID;
        this.artifactPieceObject = artifactPieceObject;
    }
}

