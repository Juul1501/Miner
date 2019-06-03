using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int terrainWidth = 10, terrainHeight = 100;
    public float spawnPercentage = 0.05f;
    public Ground[,] ground;
    public Vector3Int generatePos;

    public void GenerateMap()
    {
        ground = new Ground[terrainWidth, terrainHeight];
        ArtifactPiece artifactItem = new ArtifactPiece("test", 2,2);
        for (int y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++ )
            {
                if (Random.value < spawnPercentage)
                {
                    ground[x, y] = new ArtifactGround(1, 1, MapManager.Instance.groundPrefabs[1], true,ArtifactTier.Common,MapManager.Instance.artifactPrefabs[0], new Vector2Int(x,-y), artifactItem);
                }
                else
                {
                    ground[x, y] = new Ground(1, 1, MapManager.Instance.groundPrefabs[0], true, new Vector2Int(x, -y),GroundType.ground);
                }
                
            }
        }
    }
    
    public Ground GetGround (int x, int y) 
    {
       Ground tile = ground[x,-y];
       return tile;
    }

    public void SetGround (int x, int y, Ground stGround)
    {
        ground[x,y] = stGround;
    }
    

}

