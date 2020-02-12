using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewCharacterMover : MonoBehaviour
{
    public float moveSpeed = 50f, jumpSpeed = 150f, gravity = 3f;
    private Vector3 position;
    private CharacterController controller;
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
            }

            if (position.x != 0 || position.z !=0)
            {
                controller.transform.forward = new Vector3(position.x, 0, position.z);
            }
        }

        position.y -= gravity;
        controller.Move(position * Time.deltaTime);
    }
}
