﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGernerator : MonoBehaviour
{
    public int terrainWidth = 0, terrainHeight = 0;
    public float spawnPercentage;
    public GameObject[] groundObjects;
    public Vector3 generatePos;

    
    private void Start()
    {
        spawnPercentage = spawnPercentage / 100f;
        GenerateTerrain();
    }
    void GenerateTerrain()
    {
        for (int x = 0; x < terrainWidth; x++)
        {
            for (int y = 0; y < terrainHeight; y++)
            {
                generatePos = new Vector3(x, y, 0);
                if (Random.value < spawnPercentage)
                {
                    Instantiate(groundObjects[1], generatePos, Quaternion.identity);
                }
                else
                {
                    Instantiate(groundObjects[0], generatePos, Quaternion.identity);
                }
                
            }
        }
    }
}