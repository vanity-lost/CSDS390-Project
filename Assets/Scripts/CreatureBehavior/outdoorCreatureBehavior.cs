using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using UnityEngine;

public class outdoorCreatureBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    // Update is called once per frame
    void Update()
    {
        Vector3 creatureLocation = getCreatureLocation();
        Vector3 subLocation = getSubLocation();
        if (isWithinAttackRange(creatureLocation, subLocation) {
            attack();
        } else if (isWithinSensingRange(creatureLocation, subLocation, creatureDetectionDistance(isSubLightsOn(), isSubEngineOn()))) {
            moveToSub();
        } else
        {
            uninformedSearch();
        }
    }

    // Gets location of creature (from another class)
    private Vector3 getCreatureLocation() { }

    // Gets location of submarine (from another class) 
    private Vector3 getSubLocation() { }

    // True if submarine is within attacking range; false otherwise
    private bool isWithinAttackRange(Vector3 creatureLocation, Vector3 playerLocation) { }

    // True if submarine is within sensing range; false otherwise
    private bool isWithinSensingRange(Vector3 creatureLocation, Vector3 playerLocation, float creatureDetectionDistance) { }

    // True if submarine's outside lights are on; false otherwise
    private bool isSubLightsOn() { }

    // True if submarine's engine is on; false otherwise
    private bool isSubEngineOn() { }

    // Calculates how far away the creature can detect the submarine based on lights and engine status
    private float creatureDetectionDistance(bool subLightsStatus, bool subEngineStatus) { }

    // Creature attacks submarine and triggers hull breach event
    private void attack() { }

    // Creature moves towards submarine
    private void moveToSub() { }

    // Creature idles and searches randomly for submarine
    private void uninformedSearch() { }
    */
}
