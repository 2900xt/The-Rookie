using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MathPatternGame : MonoBehaviour
{
    int[] ansGrid, curGrid;
    public bool solved;

    public TextMeshProUGUI[] buttonGrid;
    public TextMeshProUGUI modelBoardText;
    bool[] clicked;
    char[] symbols = { 'A', 'B'};

    public Color col;
    
    public void InitGame()
    {
        ansGrid = new int[9];
        curGrid = new int[9];
        clicked = new bool[9];
        solved = false;
        modelBoardText.text = "";

        for(int i = 0; i < 9; i++)
        {
            buttonGrid[i].transform.parent.GetComponent<Image>().color = col;
        }

        List<int> list = new List<int>();
        for(int i = 0; i < 9; i++)
        {
            list.Add(i + 1);
        }

        for(int i = 0; i < 9; i++)
        {
            if (i % 3 == 0) modelBoardText.text += "\n";
            int ind = Random.Range(0, list.Count);
            ansGrid[i] = list[ind] % 2;

            modelBoardText.text += symbols[list[ind]%2] + "\t";
            list.Remove(list[ind]);
        }

        for (int i = 0; i < 9; i++)
        {
            list.Add(i + 1);
        }

        for (int i = 0; i < 9; i++)
        {
            int ind = Random.Range(0, list.Count);

            curGrid[i] = list[ind] % 2;
            buttonGrid[i].text = symbols[list[ind]%2] + "";
            list.Remove(list[ind]);
        }
    }

    public bool isSolved()
    {
        return solved;
    }

    public void check()
    {
        for(int i = 0; i < 9; i++)
        {
            if (curGrid[i] != ansGrid[i])
            {
                solved = false;
                return;
            }
        }

        solved = true;
    }

    public void SwapElements(int a, int b)
    {
        int tmp = curGrid[b];
        curGrid[b] = curGrid[a];
        curGrid[a] = tmp;

        buttonGrid[a].text = symbols[curGrid[a]] + "";
        buttonGrid[b].text = symbols[curGrid[b]] + "";

        clicked[a] = false;
        clicked[b] = false;
        buttonGrid[a].transform.parent.GetComponent<Image>().color = col;
        buttonGrid[b].transform.parent.GetComponent<Image>().color = col;
        check();
    }

    public SoundManager sm;

    public void OnClick(int ind)
    {
        sm.Play("ClickSFX");
        clicked[ind] = true;
        buttonGrid[ind].transform.parent.GetComponent<Image>().color = Color.white;

        List<int> list = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            if (clicked[i]) list.Add(i);
        }

        if (list.Count == 2)
        {
            SwapElements(list[0], list[1]);
        }
    }
}
