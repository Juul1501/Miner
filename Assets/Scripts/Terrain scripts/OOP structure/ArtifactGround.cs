using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGround : Ground
{
    
    public ArtifactTier artifactTier;
    public UnityEngine.GameObject artifactObject;



    public ArtifactGround(int depthlevel,int toughNess,UnityEngine.GameObject groundObject,bool mineable, ArtifactTier artifactTier, UnityEngine.GameObject artifactObject, Vector2Int position) : base(depthlevel,toughNess,groundObject,mineable,position)
    {
        this.artifactTier = artifactTier;
        this.artifactObject = artifactObject;

    }
}