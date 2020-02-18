using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    public void RemoveTrigger(GameObject other)
    {
        if (gameObject.tag == "Player")
        {
            other.GetComponent<Collider>().enabled = false;
        }
    }

}
