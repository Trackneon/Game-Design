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
    public GameObject enemyPrefab;
    public GameObject impactEffect;
    
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = weaponObj.weaponColor;
        rigidbodyObj = GetComponent<Rigidbody>();
        rigidbodyObj.AddForce(Forces);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


}