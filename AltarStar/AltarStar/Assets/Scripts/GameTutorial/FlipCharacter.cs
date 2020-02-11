using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    private Vector3 orientation;

    // Update is called once per frame
    private void Flip(float direction)
    {
        orientation.y = direction;
        transform.rotation = Quaternion.Euler(orientation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Flip(180);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Flip(0);
    }
}
