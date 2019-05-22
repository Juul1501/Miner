using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{

    public GameObject followObject;
    public float lerpSpeed;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =  Vector3.Lerp (this.gameObject.transform.position , new Vector3( this.gameObject.transform.position.x, followObject.transform.position.y, this.gameObject.transform.position.z), lerpSpeed); 

    }
}
