using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpdateValue : MonoBehaviour
{
    public float data = 1;
    public float health;
    public FloatData newData;
    public FloatData mData;

    public bool isDead = false;

    void Start()
    {
        health = data;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            health += newData.value;
        }

        if (other.gameObject.tag == "Missile")
        {
            health += mData.value;
        }


        //if (health <= 0f)
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Die");
        //    return;
        //}
    }

    void Update()
    {
        //health += newData.value;
        //Debug.Log("jkl");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Destroy(gameObject);
    }
}
