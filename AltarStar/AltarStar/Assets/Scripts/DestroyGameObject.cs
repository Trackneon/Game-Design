using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public FloatData data;
    public GameObject obj;

    void Start()
    {
        data.value = 1f;
    }
    public void DestroyObj()
    {
        if (data.value <= 0)
        {
            Destroy(obj);
        }
    }

}
