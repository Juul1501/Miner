using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapZone : MonoBehaviour
{
    public puzzle p;
    public GameObject correctPiece;
    private void OnTriggerEnter(Collider piece)
    {
        if(piece.gameObject == correctPiece)
        {
            piece.GetComponent<PuzzlePiece>().grabable = false;
            piece.gameObject.transform.position = transform.position;
            Destroy(piece.GetComponent<Rigidbody>());
            Destroy(piece.GetComponent<Collider>());
            p.onsnap();
       
        }
    }
    // Start is called before the first frame update
    //dit is echt puur testing verwijder later

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
