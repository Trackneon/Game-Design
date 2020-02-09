using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public bool isFollowing;
    public enum State
    {idle, isFollowing}
    public State state;
    public GameObject player;
    
    void Start()
    {
        target = player.transform;
    }

    
    void Update()
    {
        switch (state)
        {
            case State.idle:
                break;
            case State.isFollowing:
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            state = State.isFollowing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            state = State.idle;
        }
    }


}
