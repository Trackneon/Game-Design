using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehaviors : MonoBehaviour
{

    public UnityEvent StartEvent;

    // Start is called before the first frame update
    void Start()
    {
        StartEvent.Invoke();
    }

}
