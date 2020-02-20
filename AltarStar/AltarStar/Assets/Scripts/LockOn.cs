using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
//    private int current = 0; 
//private bool locked = false; 
//public CharacterController controller;
//public GameObject[] enemyLocationList;
//public GameObject closestEnemy;
//public Transform targetEnemy; 


// void Update()
//    {
//        controller = GetComponent<CharacterController>();


//        if (closestEnemy != null && locked)

//        {
//            targetEnemy.active = true;
//            targetEnemy.position.y = (closestEnemy.transform.position.y + 1);
//            targetEnemy.transform.position.x = (closestEnemy.transform.position.x);
//            targetEnemy.transform.position.z = (closestEnemy.transform.position.z);
//        }
//else
//        {
//            targetEnemy.active = false;
//        }


//        if (Input.GetButtonDown("Lock"))
//        {
//            //Looks for the closestEnemy enemy
//            FindClosestEnemy();
//            locked = !locked;
//        }
//        if (locked)
//        {
//            //If there aren't any enemies (or the player killed the last one targeted) make sure that the lock is false
//            if (!closestEnemy)
//            {
//                targetEnemy.active = false;
//                locked = false;
//                closestEnemy = null;
//            }
//            if (controller.isAttacking)
//            {
//                transform.LookAt(Vector3(closestEnemy.transform.position.x, transform.position.y, closestEnemy.transform.position.z));
//            }
                
//        }

//    }


//    public void FindcClosestEnemy()
//    {
//    // Find all game objects with tag Enemy
//    enemyLocationList = GameObject.FindGameObjectsWithTag("Enemy"); 
//    //var closestEnemy : GameObject; 
//    var distance = Mathf.Infinity;
//    var position = transform.position; 
//    // Iterate through them and find the closestEnemy one
//    foreach (var gameObj in enemyLocationList) 
//        { 
//            var diff = (gameObj.transform.position - position);
//    var curDistance = diff.sqrMagnitude; 


//         if (curDistance < distance) 
//         { 
//             closestEnemy = gameObj; 
//             distance = curDistance; 
//         }
            
//        }
//        return closestEnemy;
    }
