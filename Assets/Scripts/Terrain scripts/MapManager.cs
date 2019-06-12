﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public Map map1;
    public Map map2;
    public Texture2D texture;
    public GameObject[] groundPrefabs;
    public GameObject[] artifactPrefabs;
    public Sprite[] sprites;
    public Queue<ArtifactPiece> aftifacts;
    public Material groundMat;

    private static MapManager instance = null;
     
    public static MapManager Instance
    {
        get
        { 
            return instance; 
        }
    }
     
    private void Awake()
    {
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
        int r = 0;
        GameObject parent = new GameObject("Map");
        
        for (int y = 0; y < map.terrainHeight; y++)
        {
            r++;
            if (r > 16) r = 1;

            for (int x = 0; x < map.terrainWidth; x++)
            {
                Material groundTile = new Material(Shader.Find("Standard"));
                groundTile.EnableKeyword("_NORMALMAP");
                texture = Resources.Load<Texture2D>("R"+(r).ToString()+" T"+(x + 1).ToString());
                Texture2D normal = Resources.Load<Texture2D>("kartonnormal");
                groundTile.SetTexture("_MainTex", texture);
                groundTile.SetTexture("_BumpMap", normal);
                map1.ground[x, y].groundObject.GetComponent<MeshRenderer>().material = groundTile;
                map1.groundGameObjects[x,y] = Instantiate(map.ground[x, y].groundObject,new Vector3Int(map.ground[x, y].position.x, map.ground[x, y].position.y,0),new Quaternion (0,0,90,0),parent.transform) as GameObject;
            }
        }
    }
}
