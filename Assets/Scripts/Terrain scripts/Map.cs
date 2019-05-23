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
        for (int y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++ )
            {
                if (Random.value < spawnPercentage)
                {
                    ground[y, x] = new ArtifactGround(1, 1, MapManager.Instance.groundPrefabs[0], true,ArtifactTier.Common,MapManager.Instance.artifactPrefabs[0], new Vector2Int(x,y));
                    generatePos = new Vector3Int(ground[y, x].position.x, ground[y, x].position.y,0);
                    MonoBehaviour.Instantiate(ground[y, x].groundObject,generatePos, Quaternion.identity);
                }
                else
                {
                    Debug.Log(MapManager.Instance.groundPrefabs[0].name);
                    var i = MapManager.Instance.groundPrefabs[0];
                    ground[y,x] = new Ground(1,1,i,true,new Vector2Int(x,y));
                    generatePos = new Vector3Int(ground[y, x].position.x, ground[y, x].position.y, 0);
                    Debug.Log(i.tag);
                    var j = ground[y, x].groundObject;
                    Object.Instantiate(j, generatePos, Quaternion.identity);
                }
                
            }
        }
    }
    
    Ground GetGround (int x, int y) 
    {
       Ground tile = ground[x,y];   
       return tile;
    }

    void SetGround (int x, int y, Ground stGround)
    {
        ground[x,y] = stGround;
    }
    

}

