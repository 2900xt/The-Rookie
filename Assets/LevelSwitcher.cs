using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{

    public int switchTo = 1;
    public bool ready;
    // Update is called once per frame
    void Update()
    {
        while (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) return;
        if(!ready)
        {
            return;
        }

        SceneManager.LoadScene("Level_"+switchTo);
    }
}
