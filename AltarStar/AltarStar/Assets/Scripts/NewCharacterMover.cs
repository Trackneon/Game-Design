using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewCharacterMover : MonoBehaviour
{
    public float moveSpeed = 50f, gravity = 3f, jumpSpeed = 20f, dashSpeed = 200f;
    private Vector3 position;
    private CharacterController controller;
    public float pushPower = 2.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            position.x = -moveSpeed * Input.GetAxis("Horizontal");
            position.z = -moveSpeed * Input.GetAxis("Vertical");


            if (Input.GetButtonDown("Jump"))
            {
                position.y = jumpSpeed;
                position.x = -dashSpeed * Input.GetAxis("Horizontal");
                position.z = -dashSpeed * Input.GetAxis("Vertical");
            }

            if (position.x != 0 || position.z !=0)
            {
                controller.transform.forward = new Vector3(position.x, 0, position.z);
            }

        }

        position.y -= gravity;
        controller.Move(position * Time.deltaTime);


    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushPower;
    }

}
