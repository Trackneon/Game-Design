using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossDoor : MonoBehaviour
{
    public GameObject door;
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetActive(true);
        }

    }
}
