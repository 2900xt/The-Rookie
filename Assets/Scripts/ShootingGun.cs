using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGun : MonoBehaviour
{
    private Vector3 shootingPos;
    private LineRenderer lr;
    public Transform gunTip, camera, player;

    public float shootCooldown = 1.0f, curCooldown;

    // Start is called before the first frame update

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Shoot()
    {
        RaycastHit hit;
        if(!Physics.Raycast(camera.position, camera.forward, out hit))
        {
            return;
        }

        shootingPos = hit.point;

        lr.positionCount = 2;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, shootingPos);

        if(hit.transform.GetComponent<EntityData>() != null)
        {
            hit.transform.GetComponent<EntityData>().HP -= 30.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(curCooldown <= 0)
            {
                Shoot();
                curCooldown = shootCooldown;
            }
        }

        if(curCooldown <= shootCooldown * 0.9f)
        {
            lr.positionCount = 0;
        }

        curCooldown -= Time.deltaTime;
    }
}