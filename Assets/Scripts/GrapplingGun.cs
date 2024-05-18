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
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (!Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            return;
        }

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

    void StopGrapple()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }
}
