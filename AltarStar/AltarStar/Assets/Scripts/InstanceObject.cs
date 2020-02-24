using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Instancing Object")]
public class InstanceObject : ScriptableObject
{
    public GameObject prefab;

    public void CreateInstance(GameObject instance)
    {
        Instantiate(instance);
    }
    
    public void CreateInstanceAtLocation(Vector3Data location)
    {
        Instantiate(prefab, location.value, Quaternion.identity);
    }
}
