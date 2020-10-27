using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MinigameModel
{
    private Vector3 _location;
    private string _minigameName;

    public Vector3 Location
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

    public string MinigameName
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

public class IndoorCreatureBehaviorTemp : MonoBehaviour
{

    #region <-- Fields -->

    //const Transform[] SUB_ROOMS = [];
    const float minGoalDistanceFromPlayer = 100f;
    public GameObject player;
    public GameObject[] minigameObjects;
    private Transform goal;
    private NavMeshAgent agent;
    private MinigameModel nextMinigameSabatageLocation;

    #endregion

    #region <-- Unity Methods -->

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        runFromPlayer();
    }

    #endregion

    #region <-- Functions -->

    // To be called in an update
    // Creature moves towards player
    private void moveToPlayer()
    {
        //TODO: Animation will be triggered here
        //GetComponent<Animator>().Play("...");
        agent.destination = player.transform.position;
    }

    // To be called in an update
    // Creature runs away from player
    private void runFromPlayer()
    {
        agent.destination = -1 * player.transform.position;
    }

    // To be called once to find the next sabatage location
    // Next sabatage location is found
    private void nextMinitaskSabatageLocation()
    {
        List<MinigameModel> locationsAwayFromPlayer = new List<MinigameModel>;

        foreach(GameObject minigameObject in minigameObjects)
        {
            if (isWithinDistance(player.transform.position, minigameObject.transform.position, minGoalDistanceFromPlayer))
            {
                locationsAwayFromPlayer.Add(new MinigameModel
                {
                    Location = minigameObject.transform.position,
                    MinigameName = minigameObject.ToString()
                });
            }
        }

        //Debug.Assert(locationsAwayFromPlayer.Count > 0);
        int randomIndex = Random.Range(0, locationsAwayFromPlayer.Length - 1);
        nextMinigameSabatageLocation = locationsAwayFromPlayer[randomIndex];

    }

    #endregion

    #region <-- Helper Functions -->

    private bool isWithinDistance(Vector3 locationA, Vector3 locationB, float distance)
    {
        if ((locationA - locationB).magnitude >= distance)
        {
            return true;
        }
        return false;
    }

    #endregion
}
