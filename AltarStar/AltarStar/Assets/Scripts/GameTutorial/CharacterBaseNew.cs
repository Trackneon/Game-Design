using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseNew : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float gravity = -3f;//9.81 is default
    public float jumpSpeed = 75f;

    public CharacterController Controller { get; set; }
    protected Vector3 location;
    protected Vector3 orientation;

    public virtual void Move()
    {
        location.x = Input.GetAxis("Horizontal") * moveSpeed;
        location.y += gravity * Time.deltaTime;
        Controller.Move(location * Time.deltaTime);
    }

    public virtual void Jump()
    {
        if (Controller.isGrounded)
        {
            location.x = Input.GetAxis("Horizontal") * moveSpeed;
        }

    }

}
