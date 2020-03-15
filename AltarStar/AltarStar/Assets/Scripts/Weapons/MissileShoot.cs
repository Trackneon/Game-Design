using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShoot : MonoBehaviour
{

    public WeaponConfig weaponObj;
    public Transform bullet;
    public Transform location;
    public float timeBetweenShots = 1f;

    private float timestamp;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time >= timestamp && Input.GetButtonDown("Fire2"))
        {
            Fire();
            timestamp = Time.time + timeBetweenShots;
        }
    }

    public void Fire()
    {
        var ammo = Instantiate(bullet, location.position, location.rotation);
        ammo.GetComponent<AmmoHandler>().weaponObj = weaponObj;
    }
}
