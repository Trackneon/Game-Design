using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public GameObject door;

    public void DestroyDoor()
    {
        door.SetActive(false);
    }

}
