using System;
using UnityEngine;

[Serializable]
public class ArtifactGround : Ground
{
    
    public ArtifactTier artifactTier;
    public GameObject artifactSprite;
    public Item artifactPiece;



    public ArtifactGround(int depthlevel,int toughNess,GameObject groundObject,bool mineable, ArtifactTier artifactTier, GameObject artifactObject, Vector2Int position, Item artifactItem) : base(depthlevel,toughNess,groundObject,mineable,position, GroundType.artifactGround)
    {
        this.artifactTier = artifactTier;
        this.artifactSprite = artifactObject;
        this.artifactPiece = artifactItem;
    }
}