using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingInterface : MonoBehaviour
{
    public GameObject hackTooltip;
    public GameObject allOnGame, matchGame, organizeGame;
    public ObjectToHack toHack;

    public int activeHack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hack"))
        {
            hackTooltip.SetActive(true);
            toHack = other.GetComponent<ObjectToHack>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hack"))
        {
            hackTooltip.SetActive(false);
            toHack = null;
        }
    }

    private void Update()
    {
        if(activeHack != -1)
        {
            switch(activeHack)
            {
                case 0:
                    if(allOnGame.GetComponent<Clicker>().solved)
                    {
                        activeHack = -1;
                    }
                    break;
                case 1:
                    if(organizeGame.GetComponent <OrganizeMinigame>().solved)
                    {
                        activeHack = -1;
                    }
                    break;
                case 2:
                    if (matchGame.GetComponent<MathPatternGame>().solved)
                    {
                        activeHack = -1;
                    }
                    break;
            }

            if(activeHack == -1)
            {
                toHack.HackAll();
                toHack = null;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.Find("Player").GetComponent<PlayerMovement>().frozen = false;
            }

            return;
        }

        if (hackTooltip.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //hack
                Debug.Log("Hacking");

                int type = Random.Range(0, 3);
                switch (type)
                {
                    case 0:
                        allOnGame.SetActive(true);
                        allOnGame.GetComponent<Clicker>().Init();
                        break;
                    case 1:
                        organizeGame.SetActive(true);
                        organizeGame.GetComponent<OrganizeMinigame>().Init();
                        break;
                    case 2:
                        matchGame.SetActive(true);
                        matchGame.GetComponent<MathPatternGame>().InitGame();
                        break;
                }


                activeHack = type;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<PlayerMovement>().frozen = true;
                hackTooltip.SetActive(false);
            }
        }
        else 
        {
            matchGame.SetActive(false);
            organizeGame.SetActive(false);
            allOnGame.SetActive(false);
        }

    }
}