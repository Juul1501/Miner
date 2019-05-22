using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGround : Ground
{
    
    public ArtifactTier artifactTier;
    public UnityEngine.GameObject artifactObject;
    public ArtifactPiece artifactPiece;



    public ArtifactGround(int depthlevel,int toughNess,UnityEngine.GameObject groundObject,bool mineable, ArtifactTier artifactTier, UnityEngine.GameObject artifactObject, ArtifactPiece artifactPiece) : base(depthlevel,toughNess,groundObject,mineable)
    {
        this.artifactTier = artifactTier;
        this.artifactObject = artifactObject;
        this.artifactPiece = artifactPiece;

    }
}