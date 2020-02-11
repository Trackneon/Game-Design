using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthony : MonoBehaviour
{
    public GameAction GameActionObj;

    public void Yell()
    {
        Debug.Log("Anthony");
    }
    // Start is called before the first frame update
    void Start()
    {
        GameActionObj.Raise();
    }

    void Awake()
    {

    }

}
