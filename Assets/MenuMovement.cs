using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public Transform target;

    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
