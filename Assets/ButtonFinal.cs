using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonFinal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextelement;
    string code = "896";
    public void toggleOn(int num)
    {
        myTextelement.text += num + "";
        if (myTextelement.text.Length > code.Length)
        {
            myTextelement.text = "";
        } 

        finishGame();
    }

    public void finishGame()
    {
        if (myTextelement.text.Equals(code))
        {
            SceneManager.LoadScene("EndGame");
            return;
        }
    }
}
