using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOutdoorCreature : MonoBehaviour
{
    public GameObject monster;
    public CameraShake camera;
    public MoveOutdoorEnemy moveMonster;

    public static Vector3 subVector = new Vector3(0.0f, 0.0f, 0.0f);
    public static Vector3 monsterVector = new Vector3(0.0f, 0.0f, 0.0f);

    private float speed = 2.0f;
    private float subDistance = 0;

    private bool reset = false;
    public bool isAttacking = false;
    public bool monsterStop = false;

    private int numAttacks = 0;

    void Awake()
    {
        subVector = GameObject.Find("Submarine").transform.position;
    }

    void Update()
    {
        if (MonsterAppear() && !monsterStop)
        {
            StartCoroutine(moveMonster.Move(monsterVector, subVector, speed));
            if (moveMonster.attack == true)
            {
                monsterStop = true;
                Attack();
            }
        }
    }

    bool MonsterAppear()
    {
        bool status = false;

        GetSubDistance();
        //Debug.Log(subDistance);
        if (subDistance == 0.0f)
        {
            monster.SetActive(true);
            FindMonster();
            status = true;
        }

        return status;
    }

    void FindMonster()
    {
        monsterVector = monster.transform.position;
    }

    void SpawnMonster()
    {

    }

    //void MoveMonster()
    //{
    //    float step = speed * Time.deltaTime;
    //    transform.position = Vector3.MoveTowards(transform.position, subVector, step);
    //    if (Vector3.Distance(monsterVector, subVector) < 6.0f)
    //    {
    //        monsterStop = true;
    //        Attack();
    //    }

    //}

    void GetSubDistance()
    {
        subDistance = SubDistanceTracker.traveledDistance;
    }

    public void Attack()
    {
        float elapsedTime = 0.0f;
        bool broken = false;
        int test = 0;

        isAttacking = true;
        SubHealth.monsterAttack++;
        numAttacks++;
        GlobalData.hullBroken = true;
        broken = true;
        StartCoroutine(camera.Shake(0.15f, 0.4f));
        Debug.Log("it works here");
        Debug.Log("elapsed time: " + elapsedTime);
        while (broken == true && numAttacks < 3)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("elapsed time: " + elapsedTime);
            if (elapsedTime >= 15.0f)
            {
                StartCoroutine(camera.Shake(0.15f, 0.4f));
                SubHealth.monsterAttack++;
                numAttacks++;
                Debug.Log("number of attacks: " + numAttacks);
                elapsedTime = 0.0f;
            }
            broken = checkHull();
        }
        elapsedTime = 0;
        numAttacks = 0;
    }

    bool checkHull()
    {
        bool status = true;
        if (GlobalData.hullBroken == false)
        {
            status = false;
        }
        return status;
    }

    void ResetMonster()
    {
        isAttacking = false;
        monster.SetActive(false); 
    }

}
