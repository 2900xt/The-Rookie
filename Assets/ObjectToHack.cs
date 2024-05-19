using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToHack : MonoBehaviour
{
    public List<Hackable> toHackList;

    public void HackAll()
    {
        foreach(Hackable h in toHackList)
        {
            h.isHacked = true;
        }
    }
}
