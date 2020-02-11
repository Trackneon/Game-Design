using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class MoveController : MonoBehaviour
{

    private CharacterController controller;
    public ScriptableObject mover;
    private IMove IMover;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        IMover = mover as IMove;
    }

    public void ChangeMover(ScriptableObject newMover)
    {
        IMover = newMover as IMove;
    }

    // Update is called once per frame
    void Update()
    {
        IMover.Move(controller);
    }
}
