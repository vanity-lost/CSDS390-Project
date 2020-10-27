using System;
using UnityEngine;
using UnityEngine.AI;

public class minigameModel
{
    private Vector3 _location;
    private string _minigameName;

    public Vector3 location
    {
        get
        {
            return _location;
        }
        set
        {
            _location = value;
        }
    }

    public string _minigameName
    {
        get
        {
            return _minigameName;
        }
        set
        {
            _minigameName = value;
        }
    }
}

public class indoorCreatureBehaviorTemp : MonoBehaviour
{
    //const Transform[] SUB_ROOMS = [];
    const float minGoalDistanceFromPlayer = 100f;

    public GameObject player;
    public GameObject[] minigameObjects;
    private Transform goal;
    private NavMeshAgent agent;
    private nextMinigameSabatageLocation;

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

    private Vector3 nextMinitaskSabatageLocation()
    {
        Vector3[] locationsAwayFromPlayer;

        foreach(GameObject minigameObject in minigameObjects)
        {
            if ((player.transform.position - minigameObject.transform.position).magnitude >= minGoalDistanceFromPlayer)
        }

        Random.Range(0, minigameObjects.Length - 1)
    }
}
