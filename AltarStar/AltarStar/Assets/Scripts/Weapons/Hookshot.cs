using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookshot : MonoBehaviour
{
    //Camera cam;
    Rigidbody rb;

    RaycastHit grapplePoint;


    bool isGrappling = false;


    float chainDistance;


    public float grappleSpeed = 5f;

    void Start()
    {
        //cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //RaycastHit hit;
        //float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);

        //if(Physics.Raycast(transform.position, (forward), out hit))
        //{
        //    theDistance = hit.distance;
        //    Debug.Log(theDistance + " " + hit.collider.gameObject.name);
        //}


        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);



        if (Input.GetButtonDown("Hookshot") && Physics.Raycast(transform.position, (forward), out grapplePoint))
        {
            isGrappling = true;
            Vector3 grappleDirection = (grapplePoint.point - transform.position);
            rb.velocity = forward.normalized * grappleSpeed;
            Debug.Log(chainDistance + " " + grapplePoint.collider.gameObject.name);
            Debug.DrawRay(transform.position, forward, Color.green);
        }

        if (Input.GetButtonUp("Hookshot"))
            isGrappling = false;


        if (isGrappling)
        {

            transform.LookAt(grapplePoint.point);


            Vector3 grappleDirection = (grapplePoint.point - transform.position);


            if (chainDistance < grappleDirection.magnitude)
            {
                float velocity = rb.velocity.magnitude;

                Vector3 newDirection = Vector3.ProjectOnPlane(rb.velocity, grappleDirection);

                rb.velocity = newDirection.normalized * velocity;
            }
            else
                rb.AddForce(grappleDirection.normalized * grappleSpeed);


            chainDistance = grappleDirection.magnitude;

        }
        else
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }




}
