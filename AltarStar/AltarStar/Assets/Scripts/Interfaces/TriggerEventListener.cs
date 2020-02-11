using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventListener : MonoBehaviour, IListen
{
    public Object IRunObj;
    public IRun NewIRunObj { get; set; }
    public UnityEvent Event { get; set; }

    // Start is called before the first frame update
    public void Start()
    {
        Event = new UnityEvent();
        NewIRunObj = IRunObj as IRun;
        Event.AddListener(NewIRunObj.Run);
    }

    private void OnTriggerEnter(Collider other)
    {
        Event.Invoke();
        Event.RemoveListener(NewIRunObj.Run);
    }

}
