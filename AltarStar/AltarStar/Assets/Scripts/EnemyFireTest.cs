using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireTest : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;
    public GameObject impactEffect;

    private bool onRange = false;

    public Rigidbody projectile;

    public void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    public void Shoot()
    {

        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2f);
        }


    }

    public void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Border")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
        }
    }
}
