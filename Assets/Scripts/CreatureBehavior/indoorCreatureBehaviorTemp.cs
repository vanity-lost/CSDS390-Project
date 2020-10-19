using UnityEngine;
using UnityEngine.AI;

public class indoorCreatureBehaviorTemp : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = goal.position;
    }
}
