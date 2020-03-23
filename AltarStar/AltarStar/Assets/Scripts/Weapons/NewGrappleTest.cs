using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrappleTest : MonoBehaviour
{
    [SerializeField] private Transform debugHitTransform;
    [SerializeField] private Transform grappleTranform;

    private Rigidbody rigidbodyObj;

    private Vector3 grapplePosition;

    //public Vector3 Forces;

    private float ropeSize;

    private States presentState;

    //private CharacterController controller;
    public Transform player;

    private enum States
    {
        playerMovement,
        grapple,
        rope
    }
    void Start()
    {
        grappleTranform.gameObject.SetActive(false);
        presentState = States.playerMovement;

    }

    private void Update()
    {
        switch (presentState)
        {
            default:
            case States.playerMovement:
                //playerMovement();
                GrappleStart();
                break;
            case States.rope:
                grappleRope();
                break;
            case States.grapple:
                Grapple();
                break;
        }
    }


    private void GrappleStart()
    {
        if (Input.GetButtonDown("Hookshot"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                //Hit something
                debugHitTransform.position = hit.point;
                grapplePosition = hit.point;
                ropeSize = 0f;
                grappleTranform.gameObject.SetActive(true);
                grappleTranform.localScale = Vector3.zero;
                presentState = States.rope;
            }
        }
    }

    private void grappleRope()
    {
        grappleTranform.LookAt(grapplePosition);
        float ropeSpeed = 100f;
        ropeSize += ropeSpeed * Time.deltaTime;
        grappleTranform.localScale = new Vector3(1, 1, ropeSize);

        if (ropeSize >= Vector3.Distance(transform.position, grapplePosition))
        {
            presentState = States.grapple;
        }
    }

    private void Grapple()
    {
        grappleTranform.LookAt(grapplePosition);

        Vector3 grappleDirection = grapplePosition - transform.position;

        float grappleSpeed = Mathf.Clamp(Vector3.Distance(transform.position, grapplePosition), 30, 70);
        //float grappleSpeed = 5f;
        rigidbodyObj = GetComponent<Rigidbody>();
        rigidbodyObj.AddRelativeForce(grappleDirection * grappleSpeed / 10);
        //player.TransformDirection(grappleDirection * (grappleSpeed / 10));

        if (Vector3.Distance(transform.position, grapplePosition) < 5)
        {
            stopRope();
        }
        else if (Input.GetButtonDown("Hookshot"))
        {
            stopRope();
        }
    }
    private void stopRope()
    {
        grappleTranform.gameObject.SetActive(false);
        //presentState = States.playerMovement;
    }
}
