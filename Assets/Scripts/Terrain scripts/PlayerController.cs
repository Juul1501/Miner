using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Vector3> waypoint;
    public float moveSpeed = 3;
    public float breakTime;
    public bool isMoving = false;
    Vector3 leftMove = new Vector3(-1, 0, 0);
    Vector3 rightMove = new Vector3(1, 0, 0);
    Vector3 downMove = new Vector3(0, -1, 0);
    GameObject hitObject;
    GameObject lastHitObject;
    public int highlightAmount;
    void Start()
    {
        lastHitObject = this.gameObject;
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
        if (waypoint.Count < highlightAmount) 
        {
            hitObject = hitInfo.transform.gameObject;
            //Debug.Log(hitObject.transform.position.y);
            Ground ground = MapManager.Instance.map1.GetGround(Mathf.RoundToInt(hitObject.transform.position.x), Mathf.RoundToInt(hitObject.transform.position.y));
            
            if (ground.mineable)
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
       isMoving = true;
       float waitTime = 0.04f;
        for (int i = 0; i < waypoint.Count; i++)
            {
                Ground ground = MapManager.Instance.map1.GetGround(Mathf.RoundToInt(waypoint[i].x), Mathf.RoundToInt(waypoint[i].y));
                while (transform.position != waypoint[i])
                {
                    float step = moveSpeed * waitTime;
                    transform.position = Vector3.MoveTowards(transform.position, waypoint[i], step);
                }
                yield return new WaitForSeconds(ground.toughNess);
                
            }
        waypoint.Clear();
        isMoving = false;
    }
}
