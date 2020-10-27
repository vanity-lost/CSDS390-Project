using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class indoorCreatureBehavior : MonoBehaviour
{
    public GameObject _player; //TODO set these up 
    public GameObject _fuseBox; //TODO set these up

    private const float _ATTACK_RANGE = 10;
    private const float _SENSE_RANGE = 500;
    private const float _DIRECTIONAL_SENSE_RANGE = 500;
    private NavMeshAgent agent;

    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Decides creature's actions
        if (getFuseBoxWorkingStatus())
        {
            if (isWithinSensingRange(getCreatureLocation(), getPlayerLocation())) {
                moveAway();
            }
            else
            {
                if (isWithinFuseBoxRange(getCreatureLocation())) {
                    breakFuseBox();
                }
                else
                {
                    moveToFuseBox();
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
                Console.WriteLine("reached.");
            }
        }
    }

        // Gets location of creature (from another class)
        private Vector3 getCreatureLocation() 
        {
            return this.gameObject.transform.position;
        }

        // Gets location of player (from another class) 
        private Vector3 getPlayerLocation() 
        {
            return _player.transform.position;
        }

        // True if player is within attacking range; false otherwise
        private bool isWithinAttackRange(Vector3 creatureLocation, Vector3 playerLocation) 
        { 
            if ((creatureLocation - playerLocation).magnitude <= _ATTACK_RANGE)
            {
                return true;
            }
            return false;
        }

        // True if player is within sensing range; false otherwise
        private bool isWithinSensingRange(Vector3 creatureLocation, Vector3 playerLocation) 
        { 
            //TODO: Add different sensing ranges based on player movement/sound
            if ((creatureLocation - playerLocation).magnitude <= _SENSE_RANGE)
            {
                return true;
            }
            return false;
        }

        // True if creature is within range to sabatage fuse box; false otherwise
        private bool isWithinFuseBoxRange(Vector3 creatureLocation) 
        { 
            if ((creatureLocation - _fuseBox.transform.position).magnitude <= _ATTACK_RANGE)
            {
                return true;
            }
            return false;
        }

        //TODO: Get status of circuits. Temp solution is that they are always considered broken
        // Gets status of circuits (from another class)
        private bool getFuseBoxWorkingStatus() 
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
            agent.destination = _player.transform.position;
        }

        private void rovingPathing(Vector3 destination)
        {
            //TODO: create 3d pathing system
        }

        // Creature breaks fuse box
        private void breakFuseBox() 
        { 
            //TODO: Trigger circuits/fuses to break
        }

        // Creature moves towards fuse box
        private void moveToFuseBox() 
        {
            //TODO: Animation will be triggered here
            //GetComponent<Animator>().Play("...");
            agent.destination = _fuseBox.transform.position;
        }

        // Creature runs away from player
        private void moveAway() 
        {
            //TODO: Animation will be triggered herez`
            //GetComponent<Animator>().Play("...");
        }
    }
