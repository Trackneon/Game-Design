using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemyTarget : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 1000;
    public GameObject currentEnemy;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            FindClosestEnemy();
        }
    }
    public void FindClosestEnemy()
    {
        var targets = GameObject.FindGameObjectsWithTag("Enemy");
        float enemyDistance = maxDistance + 1;

        foreach (GameObject enemy in targets)
        {
            float distance = Mathf.Infinity;

            if(distance < maxDistance && distance < enemyDistance)
            {
                currentEnemy = enemy;
                enemyDistance = distance;
            }
        }
        
        if(enemyDistance < maxDistance + 1)
        {
            if(targets != null)
            {
                target.tag = "Enemy";
            }
            target = currentEnemy.transform;
            target.tag = "Target";
            print("New target" + target.name);
        }

     
    }
}
