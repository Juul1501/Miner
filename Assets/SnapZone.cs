using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("piece"))
        {
            Debug.Log("snap");
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.tag = "Player";
        }
    }
}
