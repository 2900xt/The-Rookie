using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrganizeMinigame : MonoBehaviour
{
    public int currentlyOn;

    public GameObject[] buttons;
    private int[] order;

    public Transform topLeft;

    void Start()
    {
        order = new int[9];
        List<int> list = new List<int>();
        for(int i = 0; i < 9; i++)
        {
            list.Add(i + 1);
        }
        
        for(int i = 0; i < 9; i++)
        {
                int ind = Random.Range(0, list.Count);
                order[i] = list[ind];
                list.Remove(order[i]);
        }


        currentlyOn = 1;
        for(int i = 0; i < 9; i++)
        {
            

        }
    }

    // Update is called once per frame
    public void Next(int pressed)
    {
        if(pressed == currentlyOn)
        {
            currentlyOn++;
            Destroy(buttons[pressed-1]);
        }

        if(currentlyOn >= 10)
        {
            gameComplete();
        }
    }

    private void gameComplete()
    {
        return;
    }
}
