using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public WeaponConfig weaponObj;
    public Transform bullet;
    public Transform location;
    
    void Start()
    {
        var child = Instantiate(weaponObj.weaponArt, transform);
        weaponObj.weaponFireAction = Fire;
        var renderer = child.GetComponent<Renderer>();
        renderer.material.color = weaponObj.weaponColor;
    }

    public void Fire()
    {
        var ammo = Instantiate(bullet, location.position, location.rotation);
        ammo.GetComponent<AmmoHandler>().weaponObj = weaponObj;
    }

    private void OnTriggerEnter(Collider other)
    {
        weaponObj.RaiseCollectAction();
    }
}