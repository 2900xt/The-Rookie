using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackable : MonoBehaviour
{
    public Transform endPos;
    public Vector3 endVector;

    public float speed;
    public GameObject particles;
    public bool isHacked;

    private void Start()
    {
        endVector = endPos.position;
    }

    private void Update()
    {
        if (!isHacked) return;

        if((-transform.position + endVector).magnitude < speed)
        {
            particles.SetActive(false);
            return;
        }

        particles.SetActive(true);

        //get unit vector
        Vector3 dir = -transform.position + endVector;
        dir /= dir.magnitude;

        transform.position += dir * Time.deltaTime * speed;
    }

    public void HackThis()
    {
        isHacked = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(endVector, transform.localScale);
    }
}
