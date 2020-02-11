using UnityEngine;
using UnityEngine.Events;

public class Destruct : MonoBehaviour
{
    public float destructTime = 3f;
    public UnityEvent destroyEvent;

    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject, destructTime);
    }

    private void Move()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
    }
}
