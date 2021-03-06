﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTarget : MonoBehaviour
{
    public Transform weapon;
    public Transform target;
    public Transform player;
    public Enemy targetgrapplePoint;
    public GameObject marker;

    public float maxAngle = 180;

    public float range = 15f;

    void Update()
    {
        UpdateTarget();

    }
    void UpdateTarget()
    {
        GameObject[] grapplePoints = GameObject.FindGameObjectsWithTag("grapplePoint");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestgrapplePoint = null;
        //float angle = Vector3.Angle(target.transform.position, transform.forward);

        foreach (GameObject grapplePoint in grapplePoints)
        {
            float distanceTograpplePoint = Vector3.Distance(transform.position, grapplePoint.transform.position);
            

            if (distanceTograpplePoint < shortestDistance)
            {
                shortestDistance = distanceTograpplePoint;
                nearestgrapplePoint = grapplePoint;
            }
        }

        if (Input.GetAxis("HookshotTarget") > 0 && nearestgrapplePoint != null && shortestDistance <= range && EnemyInFieldOfView())
        {
            target = nearestgrapplePoint.transform;
            targetgrapplePoint = nearestgrapplePoint.GetComponent<Enemy>();
            player.LookAt(target);
        }
        else
        {
            target = null;

            transform.rotation = player.rotation;
        }

        bool EnemyInFieldOfView()
        {

            Vector3 targetDir = nearestgrapplePoint.transform.position - player.transform.position;

            float angle = Vector3.Angle(targetDir, player.transform.forward);
            Debug.Log(angle);

            if (angle < maxAngle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
