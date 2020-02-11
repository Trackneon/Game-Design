using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AINavMesh : MonoBehaviour
{

    private NavMeshAgent agent;
   public Transform end;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = end;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.position;
    }
}
