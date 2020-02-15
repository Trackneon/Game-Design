using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushObject : MonoBehaviour
{
    public float mass = 300;
    public float push = 100;
    public float pushTime;
    public float force;
    Rigidbody rb;
    public float vel;
    Vector3 dir;

    Vector3 lastPos;
    float _pushTime = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.mass = mass;
    }

    bool IsMoving()
    {
        if (rb.velocity.magnitude > 0.06f)
        {
            return true;
        }
        return false;

    }

    private void Update()
    {
        //F key to Push
        vel = rb.velocity.magnitude;
        if (Input.GetKeyUp(KeyCode.C))
        {
            rb.isKinematic = true;
        }

        if (rb.isKinematic == false)
        {
            _pushTime += Time.deltaTime;
            if (_pushTime >= pushTime)
            {
                _pushTime = pushTime;
            }

            rb.mass = Mathf.Lerp(mass, push, _pushTime / pushTime);
            rb.AddForce(dir * force, ForceMode.Force);
        }
        else
        {
            rb.mass = mass;
            _pushTime = 0;

        }
    }
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (Input.GetKey(KeyCode.C))
            {
                rb.isKinematic = false;

                dir = collision.contacts[0].point - transform.position;
                // We then get the opposite (-Vector3) and normalize it
                dir = -dir.normalized;

            }
        }

    }

}
