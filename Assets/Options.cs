using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    public GameObject buttons;
    public GameObject optionScreen;



    public void TogglePanel()
    {
        buttons.SetActive(false);
        optionScreen.SetActive(true);
       
    }
    // Start is called before the first frame update

}
