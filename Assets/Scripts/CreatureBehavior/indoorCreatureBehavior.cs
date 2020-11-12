using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

/*
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
}*/

public class IndoorCreatureBehavior : MonoBehaviour
{
    private List<string> MINIGAME_GAMEOBJECT_NAMES = new List<string>() { "Control_ConsoleUVD", "Storage Closet", "Fire Extinguisher", "Engine_UV_V3", "WireHead W/ Sparks", "WireMid W/ Sparks", "WireTail W/ Sparks", "Fuse Box" };
    private float HIDE_DISTANCE = 6f;
    private float HUNT_DISTANCE = 1.8f;

    #region <-- Fields -->

    //const Transform[] SUB_ROOMS = [];
    const float minGoalDistanceFromPlayer = 1f;
    private GameObject player;
    private List<GameObject> minigameObjects;
    private Transform goal;
    private NavMeshAgent agent;
    private bool pausedDecisions = true;
    //private MinigameModel nextMinigameSabatageLocation;

    #endregion

    #region <-- Unity Methods -->

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        minigameObjects = new List<GameObject>();
        findMinigameObjects();
        StartCoroutine(delayedMove());
    }

    void Update()
    {
        //UnityEngine.Debug.Log("Current Distance: " + (agent.transform.position - player.transform.position).magnitude);
        if (!pausedDecisions)
        {
            if (GlobalData.wiresBroken || GlobalData.fuseBroken)
            {
                agent.speed = 2;
                if (huntRoam())
                {
                    moveToPlayer();
                }
            }
            else
            {
                agent.speed = 5;
                if (hideRoam())
                {
                    runFromPlayer();
                }
            }
        }
    }

    #endregion

    #region <-- Functions -->

    private void findMinigameObjects()
    {
        MINIGAME_GAMEOBJECT_NAMES.ForEach(name =>
        {
            minigameObjects.Add(GameObject.Find(name));
        });
    }

    public IEnumerator delayedMove()
    {
        yield return new WaitForSeconds(10);
        pausedDecisions = false;
    }

    private IEnumerator pauseDecisions(int time)
    {
        pausedDecisions = true;
        yield return new WaitForSeconds(time);
        pausedDecisions = false;
    }

    // To be called in an update
    // Creature moves towards player
    private void moveToPlayer()
    {
        agent.destination = player.transform.position;
    }

    // To be called in an update
    // Creature runs away from player
    private void runFromPlayer()
    {
        agent.destination = 2 * agent.transform.position - player.transform.position;
    }

    private bool hideRoam()
    {
        if (isWithinDistance(player.transform.position, agent.transform.position, HIDE_DISTANCE))
        {
            return true;
        }
        else if (isWithinDistance(player.transform.position, agent.destination, HIDE_DISTANCE))
        {
            agent.destination = hideRoamPickNewDestination();
            StartCoroutine(pauseDecisions(1));
        }
        return false;
    }

    private Vector3 hideRoamPickNewDestination()
    {
        List<Vector3> locationsAwayFromPlayer = new List<Vector3>();

        foreach (GameObject minigameObject in minigameObjects)
        {
            if (!isWithinDistance(player.transform.position, minigameObject.transform.position, HIDE_DISTANCE))
            {
                locationsAwayFromPlayer.Add(minigameObject.transform.position);
            }
        }

        //Debug.Assert(locationsAwayFromPlayer.Count > 0);
        int randomIndex = UnityEngine.Random.Range(0, locationsAwayFromPlayer.Count - 1);
        return locationsAwayFromPlayer[randomIndex];
    }

    public bool huntRoam()
    {
        if (isWithinDistance(player.transform.position, agent.transform.position, HUNT_DISTANCE))
        {
            return true;
        }
        else if (isWithinDistance(agent.destination, agent.transform.position, HUNT_DISTANCE))
        {
            StartCoroutine(pauseDecisions(2));
            agent.destination = huntRoamPickNewDestination();
            StartCoroutine(pauseDecisions(1));
        }
        return false;
    }

    private Vector3 huntRoamPickNewDestination()
    {
        int randomIndex = UnityEngine.Random.Range(0, minigameObjects.Count - 1);
        return minigameObjects[randomIndex].transform.position;
    }


    /*
    // To be called once to find the next sabatage location
    // Next sabatage location is found
    private void nextMinitaskSabatageLocation()
    {
        List<MinigameModel> locationsAwayFromPlayer = new List<MinigameModel>();

        foreach (GameObject minigameObject in minigameObjects)
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
        int randomIndex = UnityEngine.Random.Range(0, locationsAwayFromPlayer.Count - 1);
        nextMinigameSabatageLocation = locationsAwayFromPlayer[randomIndex];
    }*/

    #endregion

    #region <-- Helper Functions -->

    private bool isWithinDistance(Vector3 locationA, Vector3 locationB, float distance)
    {
        if ((locationA - locationB).magnitude <= distance)
        {
            return true;
        }
        return false;
    }

    #endregion
}
