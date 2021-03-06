﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerController : MonoBehaviour
{
    public List<Vector3> waypoint;
    public float moveSpeed = 3;
    public float breakTime;

    public float currentFuel;
    public float maxFuel;
    public float fuelDecreaseSpeed;
    public Slider fuelBar;

    public bool isMoving = false;
    Vector3 leftMove = new Vector3(-1, 0, 0);
    Vector3 rightMove = new Vector3(1, 0, 0);
    Vector3 downMove = new Vector3(0, -1, 0);
    GameObject hitObject;
    GameObject lastHitObject;
    public int highlightAmount;
    public ParticleSystem particle;

    public JsonLoader jsonLoader;
    public Upgrades playerUpgrades;
    public string upgradeSavepath;
    void Start()
    {
        jsonLoader = new JsonLoader();
        initializeUpgrades();
        
        lastHitObject = this.gameObject;
        waypoint = new List<Vector3>();
        transform.rotation = Quaternion.Euler(90,0,0);
    }


    public void initializeUpgrades()
    {
        Data d = jsonLoader.LoadJson(playerUpgrades, upgradeSavepath);
                if (d is Upgrades)
                {
                    playerUpgrades = (Upgrades)d;
                }

        maxFuel += playerUpgrades.MaxFuelUpgrade.Value;

        currentFuel = maxFuel;
        fuelBar.maxValue = maxFuel;
        highlightAmount += Mathf.RoundToInt( playerUpgrades.SlideLengthUpgrade.Value);
        moveSpeed += playerUpgrades.MoveSpeedUpgrade.Value;

    }

    void Update()
    {

        if(currentFuel > 0) DecreaseFuel();

        foreach (var touch in Input.touches)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hitInfo);
            if (hit)
            {
               if(!isMoving) HighlightGround(hitInfo);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                MovePlayer();
            }
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
              if(!isMoving)  HighlightGround(hitInfo);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
           if(!isMoving) StartCoroutine(MovePlayer()); 
        }
    }

    void HighlightGround(RaycastHit hitInfo)
    {
        if (waypoint.Count < highlightAmount && currentFuel > 0) 
        {
            hitObject = hitInfo.transform.gameObject;
            //Debug.Log(hitObject.transform.position.y);
            Ground ground = MapManager.Instance.map1.GetGround(Mathf.RoundToInt(hitObject.transform.position.x), Mathf.RoundToInt(hitObject.transform.position.y));
            
            if (ground != null && ground.mineable)
            {
                Vector3 lastPos = lastHitObject.transform.position;
                Vector3 hitPos = hitObject.transform.position;
                if (lastPos + downMove == hitPos || lastPos + leftMove == hitPos || lastPos + rightMove == hitPos)
                {  
                    hitObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
                    waypoint.Add(hitInfo.transform.position);
                    lastHitObject = hitObject;
                    
                }
            }
        }
    }

    IEnumerator MovePlayer()
    {
    if (currentFuel > 0){
       isMoving = true;
       float waitTime = 0.04f;
        for (int i = 0; i < waypoint.Count; i++)
        {
                
                Ground ground = MapManager.Instance.map1.GetGround(Mathf.RoundToInt(waypoint[i].x), Mathf.RoundToInt(waypoint[i].y));
            while (transform.position != waypoint[i])
            {
                
                transform.position = Vector3.MoveTowards(transform.position, waypoint[i], moveSpeed);
                transform.LookAt(waypoint[i], new Vector3(0f,0f,1f));
                yield return null;
            }
            
            if (ground is ArtifactGround)
            {
                ArtifactGround it = (ArtifactGround) ground;
                Inventory.instance.AddItem(it.artifactPiece);
                
            }

            MapManager.Instance.map1.groundGameObjects[Mathf.RoundToInt(waypoint[i].x), -Mathf.RoundToInt(waypoint[i].y)].SetActive(false);
                particle.Play();
                yield return new WaitForSeconds(breakTime);
        }
        waypoint.Clear();
        isMoving = false;
    }
    }

    public void DecreaseFuel ()
    {
       if(!isMoving) 
       {
           currentFuel = currentFuel - (1.5f * Time.deltaTime);
       } 
       else
       {
           currentFuel = currentFuel - (fuelDecreaseSpeed * Time.deltaTime);

       }

       if (currentFuel < 20)
       {
           //low on fuel message
       }
       

       fuelBar.value = currentFuel;
    }

}
