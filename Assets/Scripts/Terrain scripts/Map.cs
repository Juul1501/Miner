using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int terrainWidth = 10, terrainHeight = 100;
    public float spawnPercentage = 0.02f;
    public Ground[,] ground;
    public GameObject[,] groundGameObjects;
    public Vector3Int generatePos;
    private int artifactcount;
    public void GenerateMap()
    {
        ground = new Ground[terrainWidth, terrainHeight];
        groundGameObjects = new GameObject[terrainWidth,terrainHeight];
        
        for (int y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++ )
            {
                if (Random.value < spawnPercentage && artifactcount < MapManager.Instance.artifacts.Length)
                {
                    ArtifactPiece artifactPiece = new ArtifactPiece("Artifact"+artifactcount,2);
                    MapManager.Instance.artifacts[artifactcount].artifactPiece = artifactPiece;
                    ground[x, y] = MapManager.Instance.artifacts[artifactcount];
                    ground[x, y].position = new Vector2Int(x, -y);
                    artifactcount++;
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
        if(-y > 0 && -y < ground.GetLength(1))
        {
            Ground tile = ground[x,-y];
            return tile;
        }
        else
        {
            return null;
        }
    }

    public void SetGround (int x, int y, Ground stGround)
    {
        ground[x,y] = stGround;
    }
}

