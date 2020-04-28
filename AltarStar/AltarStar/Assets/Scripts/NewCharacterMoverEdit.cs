using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewCharacterMoverEdit : MonoBehaviour
{
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;

    RaycastHit grapplePoint;

    public float moveSpeed = 50f, gravity = 3f, jumpSpeed = 20f, dashSpeed = 200f;
    private Vector3 position;

    public float pushPower = 2.0f;

    public Vector3 hookshotPosition;

    private CharacterController controller;
    public GameObject player;
    private LineRenderer line;

    public AudioSource source;

    private float hookshotSize;

    private State state;

    private enum State
    {
        Normal,
        HookshotThrown,
        HookshotFlyingPlayer,
    }
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        hookshotTransform.gameObject.SetActive(false);
        debugHitPointTransform.gameObject.SetActive(false);
        state = State.Normal;
        line = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HookshotStart();
                CharacterMovement();
                break;
            case State.HookshotThrown:
                //CharacterMovement();
                HookShoot();
                break;
            case State.HookshotFlyingPlayer:
                HookshotMovement();
                line.SetPosition(0, player.transform.position);
                line.SetPosition(1, debugHitPointTransform.position);
                break;
        }

    }

    private void CharacterMovement()
    {
        if (controller.isGrounded)
        {
            position.x = -moveSpeed * Input.GetAxis("Horizontal");
            position.z = -moveSpeed * Input.GetAxis("Vertical");


            if (Input.GetButtonDown("Jump"))
            {
                position.y = jumpSpeed;
                position.x = -dashSpeed * Input.GetAxis("Horizontal");
                position.z = -dashSpeed * Input.GetAxis("Vertical");
            }

            if (position.x != 0 || position.z != 0)
            {
                controller.transform.forward = new Vector3(position.x, 0, position.z);
            }

        }

        position.y -= gravity;
        controller.Move(position * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushPower * Time.deltaTime;
    }

    private void HookshotStart()
    {
        int layerMask = 1 << 21;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        if (TestInputDownHookshot())
        {
            if (Physics.Raycast(player.transform.position, player.transform.forward, out grapplePoint, 800, layerMask))
            {
                debugHitPointTransform.position = grapplePoint.point;
                hookshotPosition = grapplePoint.point;
                hookshotSize = 0f;
                debugHitPointTransform.gameObject.SetActive(true);
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                state = State.HookshotThrown;
                //Debug.DrawRay(transform.position, forward, Color.green);
            }
        }
    }

    private void HookShoot()
    {
        hookshotTransform.LookAt(hookshotPosition);

        //float hookShootSpeed = 1000f;
        //hookshotSize = Vector3.Distance(hookshotPosition, transform.position);
        hookshotSize = Vector3.Distance(debugHitPointTransform.position, transform.position);

        source.Play();

        //hookshotSize += hookShootSpeed * Time.deltaTime;
        //hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);
        


        if (hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
        }
    }
    private void HookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeedMin = 50f;
        float hookshotSpeedMax = 100f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMultiplier = 5f;

        controller.Move(hookshotDir * hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime);

        float reachedHookshotPositionDistance = 1f;
        if (Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            StopHookshot();
        }

        if (TestInputDownHookshot())
        {
            StopHookshot();
        }

        if (TestInputJump())
        {
            StopHookshot();
        }
    }

    private void StopHookshot()
    {
        state = State.Normal;
        hookshotTransform.gameObject.SetActive(false);
        debugHitPointTransform.gameObject.SetActive(false);
    }
    private bool TestInputDownHookshot()
    {
        return Input.GetButtonDown("Hookshot");
    }

    private bool TestInputJump()
    {
        return Input.GetButtonDown("Jump");
    }
}
