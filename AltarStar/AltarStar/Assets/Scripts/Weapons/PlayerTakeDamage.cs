using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public FloatData health;
    public FloatData newData;

    void Start()
    {
        health.value = 1f;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            health.value += newData.value;
        }
    }

}
