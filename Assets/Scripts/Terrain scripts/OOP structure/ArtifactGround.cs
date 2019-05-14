using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGround : Ground
{
    public enum ArtifactTier
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    };

    public ArtifactTier artifactTier;
    public UnityEngine.GameObject artifactObject;
    public ArtifactPiece artifactPiece;



    public ArtifactGround artifactGround(ArtifactTier articactTier, UnityEngine.GameObject artifactObject, ArtifactPiece artifactPiece)
    {
        artifactTier = this.artifactTier;
        artifactObject = this.artifactObject;
        artifactPiece = this.artifactPiece;

    }
}