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
        Debug.Log(col.gameObject.ToString());
        if(col.gameObject.GetComponent<EntityData>())
        {
            col.gameObject.GetComponent<EntityData>().HP -= damage;
            Debug.Log("Did " + damage);
        }
        Destroy(gameObject);
    }
}
