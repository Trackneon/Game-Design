using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AmmoHandler : MonoBehaviour
{
    private Rigidbody rigidbodyObj;
    public Vector3 Forces;
    public WeaponConfig weaponObj;
    //public GameObject enemyPrefab;
    public GameObject impactEffect;
    //public FloatData enemyHealth;
    
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = weaponObj.weaponColor;
        rigidbodyObj = GetComponent<Rigidbody>();
        rigidbodyObj.AddRelativeForce(Forces);
        Destroy(gameObject, 2f);
    }
     void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
            return;
        }

        //if (other.gameObject.tag == "Enemy" && enemyHealth.value <= 0f)
        //{
        //    Destroy(other.gameObject);
        //}

        if(other.gameObject.tag == "Border")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.tag == "Obstacle")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
            return;
        }
    }

}