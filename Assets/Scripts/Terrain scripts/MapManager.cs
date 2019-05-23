using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public Map map1;
    public Map map2;

    public GameObject[] groundPrefabs;
    public GameObject[] artifactPrefabs;


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
        InstantiateMap(map1);
    }

    void InstantiateMap(Map map)
    {
        GameObject parent = new GameObject("Map");
        
        for (int y = 0; y < map.terrainHeight; y++)
        {
            for (int x = 0; x < map.terrainWidth; x++)
            {
                Instantiate(map.ground[x, y].groundObject,new Vector3Int(map.ground[x, y].position.x, map.ground[x, y].position.y,0),Quaternion.identity,parent.transform);
            }
        }
    }
}
