using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    public float HP;
    public float energy;
    public bool isPlayer;

    public float maxHP = 100f;

    void Start()
    {
        HP =  maxHP;
        energy = 1.0f;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            return;
        }

        //Give the player a bit of energy
        energy = Mathf.Min(1.0f, energy + Time.deltaTime * 0.25f);
    }
}
