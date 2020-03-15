using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float enemyHealth = 8f;
    private float health;
    //public float bulletDamage = -.5f;
    //public FloatData missileDamage;

    void Start()
    {
        health = enemyHealth;
    }

    public void TakeDamage (float bulletDamage)
    {
        enemyHealth += bulletDamage;

        if (health <= 0f)
        {
            Die();
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}
