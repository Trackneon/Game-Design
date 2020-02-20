using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateValue : MonoBehaviour
{
    public FloatData data;
    public FloatData newData;
    public float value = 20f;

    public void Start()
    {
        data.value = 20f;
    }
    public void ValueUpdate()
    {
        data.value += newData.value;
    }

}
