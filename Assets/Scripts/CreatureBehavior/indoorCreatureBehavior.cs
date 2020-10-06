using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indoorCreatureBehavior : MonoBehaviour
{
    private const float _ATTACK_RANGE = 10;
    private const float _SENSE_RANGE = 500;
    private const float _DIRECTIONAL_SENSE_RANGE = 500;
    private GameObject _player; //TODO set these up 
    private GameObject _circuitBox; //TODO set these up 

    void Start() { }

    void Update()
    {
        // Decides creature's actions
        if (getCircuitWorkingStatus())
        {
            if (isWithinSensingRange(getCreatureLocation(), getPlayerLocation())) {
                moveAway();
            }
            else
            {
                if (isWithinCircuitRange(getCreatureLocation())) {
                    breakCircuits();
                }
                else
                {
                    moveToCircuits();
                }
            }
        }
        else
        {
            if (isWithinAttackRange(getCreatureLocation(), getPlayerLocation())) {
                attack();
            }
            else
            {
                moveToPlayer();
            }
        }
    }

        // Gets location of creature (from another class)
        private Vector3 getCreatureLocation() 
        {
            return gameObject.Transform.position;
        }

        // Gets location of player (from another class) 
        private Vector3 getPlayerLocation() 
        {
            return _player.Transform.position;
        }

        // True if player is within attacking range; false otherwise
        private bool isWithinAttackRange(Vector3 creatureLocation, Vector3 playerLocation) 
        { 
            if ((creatureLocation - playerLocation).magnitude <= ATTACK_RANGE)
            {
                return true;
            }
            return false;
        }

        // True if player is within sensing range; false otherwise
        private bool isWithinSensingRange(Vector3 creatureLocation, Vector3 playerLocation) 
        { 
            //TODO: Add different sensing ranges based on player movement/sound
            if ((creatureLocation - playerLocation).magnitude <= SENSING_RANGE)
            {
                return true;
            }
            return false;
        }

        // True if creature is within range to sabatage circuit; false otherwise
        private bool isWithinCircuitRange(Vector3 creatureLocation) 
        { 
            if ((creatureLocation - _circuitBox.Transform.position).magnitude <= ATTACK_RANGE)
            {
                return true;
            }
            return false;
        }

        //TODO: Get status of circuits. Temp solution is that they are always considered broken
        // Gets status of circuits (from another class)
        private bool getCircuitWorkingStatus() 
        {
            return false;
        }
        

        // Creature attacks player
        private void attack() 
        { 
            //TODO: Animation will be triggered here
            //GetComponent<Animator>().Play("...");
            //TODO: Game Over Screen or cutscene should be triggered here (as player dies)
        }

        // Creature moves towards player
        private void moveToPlayer() 
        {
            //TODO: Animation will be triggered here
            //GetComponent<Animator>().Play("...");
            directPathing(_player.Transform.position);
        }

        private void directPathing(Vector3 destination)
        {
            //TODO: create 3d pathing system
        }

        private void rovingPathing(Vector3 destination)
        {
            //TODO: create 3d pathing system
        }

        // Creature breaks circuits
        private void breakCircuits() 
        { 
            //TODO: Trigger circuits/fuses to break
        }

        // Creature moves towards circuits
        private void moveToCircuits() 
        {
            //TODO: Animation will be triggered here
            //GetComponent<Animator>().Play("...");
            directPathing(_circuitBox.position);
        }

        // Creature runs away from player
        private void moveAway() 
        {
            //TODO: Animation will be triggered herez`
            //GetComponent<Animator>().Play("...");
        }
    }
