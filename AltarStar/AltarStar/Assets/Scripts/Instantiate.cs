using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject obj;
    public Transform location;
    
    public void InstantiateObj(GameObject obj)  
    {
        var newObj = Instantiate(obj, location.position, Quaternion.identity);
    }

}
