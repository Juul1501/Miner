using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var touch in Input.touches)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
            transform.position = pos;
            Debug.Log(pos);
        }
        if (Input.GetMouseButton(0))
        {

        }
    }
}
