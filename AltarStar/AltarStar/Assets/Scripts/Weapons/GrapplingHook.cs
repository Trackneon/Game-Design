using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;

    RaycastHit hookPoint;

    public bool isGrappling = false;

    public float distance;

    public float grappleSpeed = 200f;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Linecast(transform.position, target.position))
        //{
        //    Debug.Log("blocked");
        //}

        if (Input.GetButtonDown("Hookshot") && Physics.Raycast(ray, out hookPoint))
        {
            isGrappling = true;

            Vector3 grappleDirection = hookPoint.point - transform.position;

            rb.velocity = grappleDirection.normalized * grappleSpeed;

            Debug.Log("working");
        }

        if (Input.GetButtonUp("Hookshot"))
        {
            isGrappling = false;
        }

        if (isGrappling)
        {
            transform.LookAt(hookPoint.point);

            Vector3 grappleDirection = (hookPoint.point - transform.position);

            if (distance < grappleDirection.magnitude)
            {
                float velocity = rb.velocity.magnitude;

                Vector3 newDirection = Vector3.ProjectOnPlane(rb.velocity, grappleDirection);

                rb.velocity = newDirection.normalized * velocity;

                Debug.Log("grappling");
            }

            else
                rb.AddForce(grappleDirection.normalized * grappleSpeed);

                distance = grappleDirection.magnitude;
        }

        else
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

    }
}
