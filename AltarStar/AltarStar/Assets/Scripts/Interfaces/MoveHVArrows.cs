using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveHVArrows : ScriptableObject, IMove
{
    public Vector3 location { get; set; }
    public Vector3 newLoc;

    public void Move(CharacterController controller)
    {
        newLoc.y = Input.GetAxis("Horizontal");
        controller.Move(newLoc);
    }
}
