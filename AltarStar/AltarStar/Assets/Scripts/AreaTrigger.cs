using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject key;
    public AudioSource source;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            source.Play();
            door.SetActive(false);
            key.SetActive(false);
        }

    }
}
