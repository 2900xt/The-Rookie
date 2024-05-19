using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToHack : MonoBehaviour
{
    public List<Hackable> toHackList;
    public List<GameObject> toDisableList;

    public void HackAll()
    {
        foreach(Hackable h in toHackList)
        {
            h.isHacked = true;
        }

        foreach(GameObject h in toDisableList)
        {
            h.SetActive(false);
        }

        gameObject.tag = "Untagged";
        hacked = true;
    }

    public bool hacked = false;
    private void Update()
    {
        if (hacked) transform.parent.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
    }
}
