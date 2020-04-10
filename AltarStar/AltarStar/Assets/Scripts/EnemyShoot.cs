using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject impactEffect;
    public Transform player;
    public Transform enemy;
    public bool IsAttacking = false;
    public Rigidbody bullet;
    public Vector3 distance;
    public Vector3 forces;
    public float enemyDistance;
    public float fireRate = 1f;
    public float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shooting();

        distance = (enemy.position - player.position);
        distance.y = 0;
        enemyDistance = distance.magnitude;
        distance /= enemyDistance;

        if (enemyDistance <= 20)
        {
            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }
    }

    public void Shooting()
    {
        enemy.LookAt(player);

        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            var shoot = Instantiate(bullet, enemy.position, enemy.rotation);
            bullet = GetComponent<Rigidbody>();
            bullet.AddRelativeForce(forces);
            Destroy(gameObject, 2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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

        if (other.gameObject.tag == "Border")
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
