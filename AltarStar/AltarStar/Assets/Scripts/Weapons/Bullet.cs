using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 1f;

    void Damage(Transform enemy)
    {
        EnemyControl e = enemy.GetComponent<EnemyControl>();
       e.TakeDamage(bulletDamage);
        Debug.Log("jkl0");
        //if (e != null)
        //{

        //}


    }
}
