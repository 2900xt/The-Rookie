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

    public SoundManager sm;

    private SpringJoint joint;
    public EntityData owner;

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

        if (owner.energy <= 0.350f) return;
        owner.energy -= 0.20f;

        sm.Play("GrappleShot");

        grapplePoint = hit.point;
        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;

        float dist = Vector3.Distance(player.position, grapplePoint);
        joint.maxDistance = dist * 0.80f;
        joint.minDistance = dist * 0.25f;

        joint.spring = 8.5f;
        joint.damper = 7.0f;
        joint.massScale = 4.5f;

        player.gameObject.GetComponent<Rigidbody>().AddForce((grapplePoint - player.position).magnitude * (grapplePoint - player.position) * 3);
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
        if(joint) sm.Play("GrappleRetract");
        lr.positionCount = 0;
        Destroy(joint);
    }

    // Update is called once per frame
    void Update()
    {
        if (owner.GetComponent<PlayerMovement>().frozen) return;

        if(owner.energy <= 0.1)
        {
            StopGrapple();
        }

        if(joint)
        {
            owner.energy -= 0.075f * Time.deltaTime;
        }

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
