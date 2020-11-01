using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using UnityEngine;

public class outdoorCreatureBehavior : MonoBehaviour
{
    private const float _ATTACK_RANGE = 1000;
    private const float _DIRECTIONAL_SENSE_RANGE = 50000;
    private GameObject _player; //TODO set these up 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 creatureLocation = getCreatureLocation();
        UnityEngine.Vector3 subLocation = getSubLocation();
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
    private UnityEngine.Vector3 getCreatureLocation() 
    {
        return this.gameObject.transform.position;
    }

    // Gets location of submarine (from another class) 
    private UnityEngine.Vector3 getSubLocation() 
    {
        return _player.transform.position;
    }

    // True if submarine is within attacking range; false otherwise
    private bool isWithinAttackRange(UnityEngine.Vector3 creatureLocation, UnityEngine.Vector3 playerLocation) 
    {
        if ((creatureLocation - playerLocation).magnitude <= _ATTACK_RANGE)
        {
            return true;
        }
        return false;
    }

    // True if submarine is within sensing range; false otherwise
    private bool isWithinSensingRange(UnityEngine.Vector3 creatureLocation, UnityEngine.Vector3 playerLocation, float sensingRange) 
    {
        //TODO: Add different sensing ranges based on player movement/sound
        if ((creatureLocation - playerLocation).magnitude <= sensingRange)
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
        directPathing(_player.transform.position);
    }

    // Creature idles and searches randomly for submarine
    private void uninformedSearch() 
    { 
        // TODO: create pathing system
    }

    private void directPathing(UnityEngine.Vector3 destination)
    {
        //TODO: create 3d pathing system
    }
}
