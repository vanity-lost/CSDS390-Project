using UnityEngine;
using UnityEngine.AI;

public class indoorCreatureBehaviorTemp : MonoBehaviour
{
    //const Transform[] SUB_ROOMS = [];

    public GameObject player;
    public GameObject[] minigameTriggerLocations;
    private Transform goal;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        runFromPlayer();
    }

    // To be called in an update
    // Creature moves towards player
    private void moveToPlayer()
    {
        //TODO: Animation will be triggered here
        //GetComponent<Animator>().Play("...");
        agent.destination = player.transform.position;
    }

    private void runFromPlayer()
    {
        agent.destination = -1 * player.transform.position;
    }
}
