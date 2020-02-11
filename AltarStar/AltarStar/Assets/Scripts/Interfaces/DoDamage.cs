using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DoDamage : ScriptableObject, IRun
{
    public void Run()
    {
        Debug.Log("Do Damage");
    }

    public void Run(float f)
    {
        throw new System.NotImplementedException();
    }
}
