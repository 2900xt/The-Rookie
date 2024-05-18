using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour { 
    public GameObject optionbuttons;
    public GameObject menuscreens;

    public void ToMenu()
    {
        optionbuttons.SetActive(false);
        menuscreens.SetActive(true);
    }
    
    
}
