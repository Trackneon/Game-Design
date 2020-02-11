using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : ScriptableObject
{
    public CharacterController Controller { get; set; }

    protected Vector3 location;
    protected Vector3 orientation;
    public float speed = 10f;
    public float orientSpeed = 3f;

    public abstract void Move();
}
