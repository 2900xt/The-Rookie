using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class OrganizeMinigame : MonoBehaviour
{
    public int currentlyOn;

    public GameObject[] buttons;
    private int[] order;

    public Transform topLeft;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        solved = false;
        currentlyOn = 0;
        order = new int[9];
        List<int> list = new List<int>();
        for(int i = 0; i < 9; i++)
        {
            buttons[i].SetActive(true);
            list.Add(i + 1);
        }
        
        for(int i = 0; i < 9; i++)
        {
            int ind = Random.Range(0, list.Count);
            order[i] = list[ind];
            buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = order[i] + " ";
            list.Remove(order[i]);
        }
    }

    public SoundManager sm;
    // Update is called once per frame
    public void Next(int pressed)
    {

        if (order[pressed - 1] - 1 == currentlyOn)
        {
            currentlyOn++;
            buttons[pressed - 1].SetActive(false);
            sm.Play("ClickSFX");
        }

        if(currentlyOn >= 9)
        {
            gameComplete();
        }
    }

    public bool solved;
    private void gameComplete()
    {
        solved = true;
    }
}
