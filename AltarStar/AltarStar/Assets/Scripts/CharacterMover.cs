using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 20f; 
    private Vector3 position;
    private CharacterController controller;
    
   

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        position.x = -moveSpeed * Input.GetAxis("Vertical");
        position.z = moveSpeed * Input.GetAxis("Horizontal");
        controller.Move(position * Time.deltaTime);
    }
}
