using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetection : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            player.GetComponent<YetAnotherHookshot>().hooked = true;
            Debug.Log("Tocou");
        }
    }
}
