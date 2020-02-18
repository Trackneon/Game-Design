using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
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
}
