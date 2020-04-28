using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoorTrigger : MonoBehaviour
{
    public GameObject door;
    //public GameObject key;
    public AudioSource source;
    public MeshRenderer renderer;

    void Start()
    {
        source = GetComponent<AudioSource>();
        renderer.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            source.Play();
            door.SetActive(false);
            renderer.enabled = false;
        }

    }
}
