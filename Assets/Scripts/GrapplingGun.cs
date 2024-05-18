using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask grappleAble;

    public Transform gunTip, camera, player;
    public float maxDistance = 1600f;

    private SpringJoint joint;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        Debug.DrawRay(camera.position, camera.forward * maxDistance, Color.red);
        if (!Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleAble))
        {
            return;
        }

        Debug.Log("Grappling..");

        grapplePoint = hit.point;
        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;

        float dist = Vector3.Distance(player.position, grapplePoint);
        joint.maxDistance = dist * 0.80f;
        joint.minDistance = dist * 0.25f;

        joint.spring = 4.5f;
        joint.damper = 7.0f;
        joint.massScale = 4.5f;
    }

    void DrawRope()
    {
        if (!joint) return;
        lr.positionCount = 2;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    // Update is called once per frame
    void Update()
    {
        DrawRope();
        if(Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }
}
