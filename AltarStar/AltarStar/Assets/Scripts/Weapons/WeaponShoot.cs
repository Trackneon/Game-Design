﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    public WeaponConfig weaponObj;
    public Transform bullet;
    public Transform location;
    public float timeBetweenShots = 0.333f;
    public AudioSource source;

    private float timestamp;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= timestamp && Input.GetButtonDown("Fire1"))
        {
            Fire();
            timestamp = Time.time + timeBetweenShots;
        }
    }

    public void Fire()
    {
        var ammo = Instantiate(bullet, location.position, location.rotation);

        ammo.GetComponent<AmmoHandler>().weaponObj = weaponObj;

        source.Play();
    }
}
