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
        rb.velocity = transform.up * moveSpeed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision col)
    {
        //damage player here
        Destroy(gameObject);
    }
}
