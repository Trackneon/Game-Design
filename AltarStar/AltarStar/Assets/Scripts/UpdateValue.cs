using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateValue : MonoBehaviour
{
    public FloatData data;
    public FloatData newData;

    void Start()
    {
        data.value = 1f;
    }
    public void ValueUpdate()
    {
        data.value += newData.value;
    }

}
