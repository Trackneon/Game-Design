using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class GameAction : ScriptableObject
{
    public UnityAction action;
    public UnityAction<Transform> transformAction;

    //Unity action cannot be called by other events. 
    public void Raise()
    {
        action?.Invoke();
    }

    public void Raise(Transform transformObj)
    {
        transformAction?.Invoke(transformObj);
    }
}
