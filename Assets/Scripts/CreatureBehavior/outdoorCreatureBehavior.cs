using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using UnityEngine;

public class outdoorCreatureBehavior : MonoBehaviour
{
    private const float _ATTACK_RANGE = 1000;
    private const float _SENSE_RANGE = 50000;
    private const float _DIRECTIONAL_SENSE_RANGE = 50000;
    private GameObject _player; //TODO set these up 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector3 creatureLocation = getCreatureLocation();
        Vector3 subLocation = getSubLocation();
        if (isWithinAttackRange(creatureLocation, subLocation)) {
            attack();
        } else if (isWithinSensingRange(creatureLocation, subLocation, creatureDetectionDistance(isSubLightsOn(), isSubEngineOn()))) {
            moveToSub();
        } else
        {
            uninformedSearch();
        }
    }

    // Gets location of creature (from another class)
    private Vector3 getCreatureLocation() 
    {
        return gameObject.Transform.position;
    }

    // Gets location of submarine (from another class) 
    private Vector3 getSubLocation() 
    {
        return _player.Transform.position;
    }

    // True if submarine is within attacking range; false otherwise
    private bool isWithinAttackRange(Vector3 creatureLocation, Vector3 playerLocation) 
    {
        if ((creatureLocation - playerLocation).magnitude <= ATTACK_RANGE)
        {
            return true;
        }
        return false;
    }

    // True if submarine is within sensing range; false otherwise
    private bool isWithinSensingRange(Vector3 creatureLocation, Vector3 playerLocation) 
    {
        //TODO: Add different sensing ranges based on player movement/sound
        if ((creatureLocation - playerLocation).magnitude <= SENSING_RANGE)
        {
            return true;
        }
        return false;
    }

    //TODO: Once lights are working, this should be updated
    // True if submarine's outside lights are on; false otherwise
    private bool isSubLightsOn() 
    {
        return false;
    }

    //TODO: Once lights are working, this should be updated
    // True if submarine's engine is on; false otherwise
    private bool isSubEngineOn() 
    {
        return false;
    }

    //TODO: Once creature asset has been created and location can be estimated, this should return different numbers
    // Calculates how far away the creature can detect the submarine based on lights and engine status
    private float creatureDetectionDistance(bool subLightsStatus, bool subEngineStatus) 
    { 
        return 50000f;
    }

    // Creature attacks submarine and triggers hull breach event
    private void attack() 
    {
        //TODO: Trigger camera shake? Event trigger?
    }

    // Creature moves towards submarine
    private void moveToSub() 
    {
        directPathing(_player.Transform.position);
    }

    // Creature idles and searches randomly for submarine
    private void uninformedSearch() 
    { 
        // TODO: create pathing system
    }

    private void directPathing(Vector3 destination)
    {
        //TODO: create 3d pathing system
    }
}
