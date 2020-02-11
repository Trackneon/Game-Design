using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    public float smoothFactor = 10f;

    public bool lookAt = false;
  
    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.deltaTime);

        if (lookAt)
        {
            transform.LookAt(player);
        }
    }
}
