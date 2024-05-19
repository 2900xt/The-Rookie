using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityData : MonoBehaviour
{
    public float HP;
    public float energy;
    public bool isPlayer;

    public TextMeshProUGUI healthText;
    public Slider energySlider;

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

            if(isPlayer) GameObject.Find("GameManager").GetComponent<RespawnManager>().Respawn();
            else Destroy(gameObject);
            return;
        }

        //Give the player a bit of energy
        energy = Mathf.Min(1.0f, energy + Time.deltaTime * 0.035f);

        if(isPlayer)
        {
            healthText.text = "" + Mathf.Round(HP);
            energySlider.value = energy;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyProjectile>() != null)
        {
            if (isPlayer) HP -= 25;
            else HP -= 40;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Checkpoint"))
        {
            if (isPlayer) GameObject.Find("GameManager").GetComponent<RespawnManager>().respawnPoint = other.transform;
        }
    }
}
