using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
     public enum BlockType{
        GroundBlock,
        ArtifactBlock,
        StoneBlock,
        HiddenArtBlock
    };

    public int terrainWidth = 0, terrainHeight = 0;
    public float spawnPercentage;
    //public GameObject[] groundObjects;

    public Ground[,] ground;
    public Vector3Int generatePos;


    private void Start()
    {
        spawnPercentage = spawnPercentage / 100f;
        GenerateMap();
    }
    void GenerateMap()
    {
        for (int y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++ )
            {
                generatePos = new Vector3Int(x,-y, 0);
                if (Random.value < spawnPercentage)
                {
                   

                   // Instantiate(groundObjects[1], generatePos, Quaternion.identity);
                }
                else
                {
                    ground[y,x] = new Ground(1,1,MapManager.Instance.prefabs[0],true);
                    UnityEngine.Transform.Instantiate(ground[y,x].groundObject,generatePos,Quaternion.identity);
                   // Instantiate(groundObjects[0], generatePos, Quaternion.identity);
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

