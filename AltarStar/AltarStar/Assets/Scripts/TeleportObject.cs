using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform hold;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = hold.position;
            this.transform.parent = GameObject.Find("PlayerHands").transform;
        }

        else
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }



}
