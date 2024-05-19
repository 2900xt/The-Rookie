using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorMechanics : MonoBehaviour
{
    public float timer = 5.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int toLevel = PlayerPrefs.GetInt("ToLevel");
            SceneManager.LoadScene("Level_" + toLevel);
        }
    }
}
