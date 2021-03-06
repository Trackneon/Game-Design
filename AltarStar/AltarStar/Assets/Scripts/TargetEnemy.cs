﻿using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    public Transform weapon;
    public Transform target;
    public Transform player;
    public Enemy targetEnemy;
    public GameObject marker;

    public float range = 15f;

    void Start()
    {
        
    }

    void Awake()
    {

    }
    void Update()
    {
        UpdateTarget();

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (Input.GetAxis("Target") > 0 && nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            weapon.LookAt(target);
        }
        else
        {
            target = null;

            transform.rotation = player.rotation;
        }

    }


}
