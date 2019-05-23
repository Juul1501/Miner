using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGround : Ground
{
    
    public ArtifactTier artifactTier;
    public UnityEngine.GameObject artifactSprite;
    public Item artifactItem;



    public ArtifactGround(int depthlevel,int toughNess,UnityEngine.GameObject groundObject,bool mineable, ArtifactTier artifactTier, UnityEngine.GameObject artifactObject, Vector2Int position, Item artifactItem) : base(depthlevel,toughNess,groundObject,mineable,position, GroundType.artifactGround)
    {
        this.artifactTier = artifactTier;
        this.artifactSprite = artifactObject;
        this.artifactItem = artifactItem;
    }
}