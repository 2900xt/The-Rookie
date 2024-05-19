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

    public GameObject endgameButtons;

    public float maxHP = 100f;

    void Start()
    {
        HP = maxHP;
        energy = 1.0f;
    }

    void Update()
    {
        if (HP <= 0)
        {
            if (isPlayer)
            {
                GameObject.Find("GameManager").GetComponent<RespawnManager>().Respawn();
            }
            else Destroy(gameObject);
            return;
        }

        //Give the player a bit of energy
        energy = Mathf.Min(1.0f, energy + Time.deltaTime * 0.1f);

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

        if(other.gameObject.CompareTag("Laser"))
        {
            HP = -1;
        }

        if(isPlayer && other.GetComponent<AudioSource>() != null)
        {
            other.GetComponent<AudioSource>().Play();
        }

        if(isPlayer && other.GetComponent<LevelSwitcher>() != null)
        {
            other.gameObject.GetComponent<LevelSwitcher>().ready = true;
        }

        if (isPlayer && other.gameObject.CompareTag("Finish"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            endgameButtons.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isPlayer && other.gameObject.CompareTag("Finish"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            endgameButtons.SetActive(false);
        }
    }
}
