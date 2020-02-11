using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerUp : ScriptableObject, IRun, ITest
{
    public void Run()
    {
        Debug.Log("Power Up");
    }

    public void Run(float f)
    {
        throw new System.NotImplementedException();
    }

    public void Test()
    {
        Debug.Log("Power Up");
    }
}
