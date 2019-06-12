using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int terrainWidth = 10, terrainHeight = 100;
    public float spawnPercentage = 0.05f;
    public Ground[,] ground;
    public GameObject[,] groundGameObjects;
    public Vector3Int generatePos;
    public Queue<GameObject> artifacts;
    public void GenerateMap()
    {
         GameObject[] artifacts = Resources.LoadAll<GameObject>("Artifacts /");
        foreach (var artifact in artifacts)
        {
            Debug.Log("adding artifact");
            this.artifacts.Enqueue(artifact);
        }
        ground = new Ground[terrainWidth, terrainHeight];
        groundGameObjects = new GameObject[terrainWidth,terrainHeight];
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

