using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] private bool[] lightOn = new bool[9];
    [SerializeField] private GameObject[] objects = new GameObject[9];

    public void toggle(int button)
    {
        lightOn[button - 1] = !lightOn[button - 1];
        if (lightOn[button -1] == true)
        {
            objects[button - 1].GetComponent<Image>().color = Color.blue;
        }
        else
        {
            objects[button - 1].GetComponent<Image>().color = Color.white;
        }
        

    }


    public void Update()
    { 
        for(int i = 0; i < 9; i++)
        {
            if (lightOn[i] != false)
            {
                return;
            }
        }
        
        gameComplete();
    }

    private void gameComplete()
    {
        Debug.Log("Hip Hooray");
        return;
    }
    
}
