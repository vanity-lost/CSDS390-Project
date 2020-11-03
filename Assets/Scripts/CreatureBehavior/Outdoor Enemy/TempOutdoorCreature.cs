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

    private float speed = 10.0f;
    private float subDistance = 0;

    private bool reset = false;
    public bool isAttacking = false;
    public bool monsterStop = false;
    private bool monsterStatus = false;

    private int numAttacks = 0;

    System.Random random = new System.Random();

    void Awake()
    {
        subVector = GameObject.Find("Submarine").transform.position;
    }

    void Update()
    {
        MonsterAppear();
        if (monsterStatus && !monsterStop)
        {
            StartCoroutine(moveMonster.Move(monsterVector, subVector, speed));
            if (moveMonster.attack == true)
            {
                monsterStop = true;
                Attack();
            }
        }
    }

    void MonsterAppear()
    {
        GetSubDistance();
        if (monster.activeSelf == false)
        {
            switch (subDistance)
            {
                case 0.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 60.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 120.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 180.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
            }
            
        }
        else if (monster.activeSelf == true)
        {
            monsterStatus = true;
        }
        else
        {
            monsterStatus = false;
        }

    }

    void FindMonster()
    {
        monsterVector = monster.transform.position;
    }

    void SpawnMonster()
    {
        int randX = random.Next(-10, 10);
        int randY = random.Next(40, 55);
        int randZ = random.Next(50, 75);
        monster.transform.position = new Vector3(randX, randY, randZ);
        monster.SetActive(true);

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
        elapsedTime = Time.time; 
        while (broken == true && numAttacks < 3)
        {
            //elapsedTime += Time.deltaTime;
            Debug.Log("elapsed time: " + (Time.time - elapsedTime));
            if (Time.time - elapsedTime >= 5.0f) 
            {
                SubHealth.monsterAttack++;
                numAttacks++;
                Debug.Log("number of attacks: " + numAttacks);
                StartCoroutine(camera.Shake(0.15f, 0.4f));
                elapsedTime = Time.time;
            }
            broken = checkHull();
        }
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
