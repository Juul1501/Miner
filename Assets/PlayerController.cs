using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Vector3> waypoint;

    void Start()
    {
        waypoint = new List<Vector3>();
    }

    void Update()
    {

        foreach (var touch in Input.touches)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hitInfo);
            if (hit)
            {
                HighlightGround(hitInfo);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                MovePlayer();
                //waypoint.Clear();
            }
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                HighlightGround(hitInfo);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            MovePlayer();
            //waypoint.Clear();
        }
    }

    void HighlightGround(RaycastHit hitInfo)
    {
        if (!hitInfo.transform.gameObject.GetComponent<GroundBlock>().highlight)
        {
            hitInfo.transform.gameObject.GetComponent<GroundBlock>().highlight = true;
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
            waypoint.Add(hitInfo.transform.position);
        }
    }
    void MovePlayer()
    {

    }
}
