using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    public Transform weapon;
    public Transform target;
    public Enemy targetEnemy;

    public float range = 15f;

    void Start()
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
        //return nearestEnemy; //new

        if (Input.GetKey(KeyCode.LeftShift) && nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            weapon.LookAt(target);
        }
        else
        {
            target = null;
        }

    }


}
