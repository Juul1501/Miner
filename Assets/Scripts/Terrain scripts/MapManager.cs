using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public Map map1;
    public Map map2;

    public GameObject[] groundPrefabs;
    public GameObject[] artifactPrefabs;

    public int terrainWidth, terrainHeight;

    private static MapManager instance = null;
     
     // Game Instance Singleton
    public static MapManager Instance
    {
        get
        { 
            return instance; 
        }
    }
     
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
 
        instance = this;
        DontDestroyOnLoad( this.gameObject );
    }

    void Start()
    {
        map1 = new Map();
        map1.GenerateMap();
    }

    public Ground WorldPositionToTile(Vector3 worldPos, Map currentMap)
    {
       int xInt = Mathf.RoundToInt(worldPos.x);
       int yInt = Mathf.RoundToInt(worldPos.y);
       Ground groundTile = currentMap.ground[xInt, yInt];
       return groundTile;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
