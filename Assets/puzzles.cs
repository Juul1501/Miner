using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzles : MonoBehaviour
{
    public GameObject[] puzzlepanels;
    public int puzzlecounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (puzzlecounter == 0)
        {
            puzzlepanels[0].SetActive(true);
        }
        else
        {
            puzzlepanels[0].SetActive(false);
        }
        if (puzzlecounter == 1)
        {
            puzzlepanels[1].SetActive(true);
        }
        else
        {
            puzzlepanels[1].SetActive(false);
        }
        if (puzzlecounter == 2)
        {
            puzzlepanels[2].SetActive(true);
        }
        else
        {
            puzzlepanels[2].SetActive(false);
        }
    }
    
    public void onSlider(Slider i)
    {
        puzzlecounter = Mathf.RoundToInt(i.value);
        if (puzzlecounter == 0)
        {
            puzzlepanels[0].SetActive(true);
        }
        else
        {
            puzzlepanels[0].SetActive(false);
        }
        if (puzzlecounter == 1)
        {
            puzzlepanels[1].SetActive(true);
        }
        else
        {
            puzzlepanels[1].SetActive(false);
        }
        if (puzzlecounter == 2)
        {
            puzzlepanels[2].SetActive(true);
        }
        else
        {
            puzzlepanels[2].SetActive(false);
        }
    }

}
