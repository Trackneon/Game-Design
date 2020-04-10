using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject ball;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "grapplePoint")
        {
            door.SetActive(false);
            ball.SetActive(false);
        }

    }
}
