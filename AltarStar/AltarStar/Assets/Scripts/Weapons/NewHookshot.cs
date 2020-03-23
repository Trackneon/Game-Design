using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHookshot : MonoBehaviour
{
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;

    private Vector3 hookshotPosition;

    private CharacterController controller;

    RaycastHit grapplePoint;

    private float hookshotSize;

    private State state;

    private enum State
    {
        Normal,
        HookshotThrown,
        HookshotFlyingPlayer,
    }
    void Start()
    {
        hookshotTransform.gameObject.SetActive(false);
        controller = GetComponent<CharacterController>();
        state = State.Normal;
    }

    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HookshotStart();
                break;
            case State.HookshotThrown:
                HookShoot();
                break;
            case State.HookshotFlyingPlayer:
                HookshotMovement();
                break;
        }
    }

    private void HookshotStart()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        if (Input.GetButtonDown("Hookshot"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out grapplePoint))
            {
                debugHitPointTransform.position = grapplePoint.point;
                hookshotPosition = grapplePoint.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
            }
        }
    }

    private void HookShoot()
    {
        hookshotTransform.LookAt(hookshotPosition);

        float hookShootSpeed = 500f;
        hookshotSize += hookShootSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if(hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
        }
    }

    private void HookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeedMin = 10f;
        float hookshotSpeedMax = 40f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMultiplier = 5f;

        controller.Move(hookshotDir * hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime);

        float reachedHookshotPositionDistance = 1f;
        if(Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            StopHookshot();
        }

        if (Input.GetButtonDown("Hookshot"))
        {
            StopHookshot();
        }
    }

    private void StopHookshot()
    {
        hookshotTransform.gameObject.SetActive(false);
    }
}
