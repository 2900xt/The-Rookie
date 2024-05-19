using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;

    public void Respawn()
    {
        player.GetComponent<EntityData>().HP = 100;
        player.transform.position = respawnPoint.position;
    }
}
