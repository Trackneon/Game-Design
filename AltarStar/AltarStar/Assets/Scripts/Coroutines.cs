using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coroutines : MonoBehaviour
{
    private WaitForSeconds wfs;
    public float holdTime = 0.1f;
    public bool canRun { get; set; } = true;
    public UnityEvent onRunEvent;

    private void Awake()
    {
        wfs = new WaitForSeconds(holdTime);
    }

    public void Run()
    {
        StartCoroutine(routine: OnStart());
    }

    private IEnumerator OnStart()
    {
        while (canRun)
        {
            onRunEvent.Invoke();
            yield return wfs;  
        }
    }
}
