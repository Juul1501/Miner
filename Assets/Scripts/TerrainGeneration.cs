using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject cube;
    Vector3 spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 14; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                Instantiate(cube, spawnpos, Quaternion.identity);
                spawnpos.x = x;
            }
            spawnpos.y = y;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
