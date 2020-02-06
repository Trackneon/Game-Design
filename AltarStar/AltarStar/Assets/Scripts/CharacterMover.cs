using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 100f; 
    private Vector3 position;
    private CharacterController controller;
    
   

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        position.x = moveSpeed * Input.GetAxis("Horizontal");
        position.z = moveSpeed * Input.GetAxis("Vertical");
        controller.Move(position * Time.deltaTime);
    }
}
