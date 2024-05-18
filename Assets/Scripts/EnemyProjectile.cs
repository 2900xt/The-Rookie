using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    public Rigidbody rb;

    public void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
