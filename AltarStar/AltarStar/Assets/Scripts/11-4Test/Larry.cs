using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larry : MonoBehaviour
{

    public GameAction GameActionObj;

    public void Talk()
    {
        Debug.Log("Rodayne");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        GameActionObj.action += Talk;
    }

}
