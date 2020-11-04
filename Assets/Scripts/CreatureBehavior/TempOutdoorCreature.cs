using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOutdoorCreature : MonoBehaviour
{
    public GameObject monster;
    public CameraShake periscopeCamera;
    public CameraShake mainCamera;
    public MoveOutdoorEnemy moveMonster;

    public static Vector3 subVector = new Vector3(0.0f, 0.0f, 0.0f);
    public static Vector3 monsterVector = new Vector3(0.0f, 0.0f, 0.0f);

    private float speed = 8.0f;
    private float subDistance = 0.0f;
    private float saveDistance = 0.0f;

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
            bool canAttack = MonsterCanAttack();
            if (canAttack)
            {
                monsterStop = true;
                saveDistance = subDistance;
                StartCoroutine(Attack());
            }
        }
    }

    bool MonsterCanAttack()
    {
        bool distance = moveMonster.attack;
        bool lights = CheckLights();
        bool radar = CheckRadar();
        bool status = false;
        if (distance && lights && radar)
        {
            status = true;
        }
        else
        {
            status = false;
        }
        return status;
    }

    void MonsterAppear()
    {
        GetSubDistance();
        //bool subMoving = CheckSubMovement();
        //Debug.Log(subDistance);
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
            
                reset = false;

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
        int randX = random.Next(-110, -90);
        int randY = random.Next(40, 60);
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

    public IEnumerator Attack()
    {
        float elapsedTime = 0.0f;
        bool lightsOn = CheckLights();
        int test = 0;
        bool canAttack = true;

        isAttacking = true;
        SubHealth.monsterAttack++;
        numAttacks++;
        GlobalData.hullBroken = true;
        StartCoroutine(periscopeCamera.Shake(0.15f, 0.2f));
        StartCoroutine(mainCamera.Shake(0.15f, 0.2f));
        Debug.Log("number of attacks: " + numAttacks);
        //Debug.Log(elapsedTime);
        //Debug.Log(checkHull());
        Debug.Log("lights on: " + lightsOn);
        while (canAttack && numAttacks < 3)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("elapsed time: " + elapsedTime);
            if (elapsedTime >= 5.0f)
            {
                SubHealth.monsterAttack++;
                numAttacks++;
                Debug.Log("number of attacks: " + numAttacks);
                StartCoroutine(periscopeCamera.Shake(0.15f, 0.2f));
                StartCoroutine(mainCamera.Shake(0.15f, 0.2f));
                yield return new WaitForSeconds(15);
                elapsedTime = 0;
            }
            canAttack = MonsterCanAttack();
        }
        numAttacks = 0;
        ResetMonster();
        yield return 0;
    }

    bool CheckHull()
    {
        bool status = true;
        if (GlobalData.hullBroken == false)
        {
            status = false;
        }
        return status;
    }

    bool CheckLights()
    {
        bool lights = true;
        if (GlobalData.lightsOn)
        {
            lights = true;
        }
        else
        {
            lights = false;
        }
        return lights;
    }

    bool CheckRadar()
    {
        bool radar = true;
        if (GlobalData.radarOn)
        {
            radar = true;
        }
        else
        {
            radar = false;
        }
        return radar;
    }

    void ResetMonster()
    {
        reset = true;
        isAttacking = false;
        monster.SetActive(false);
    }

    bool CheckSubMovement()
    {
        bool status = false;
        GetSubDistance();
        if (subDistance - saveDistance > 0)
        {
            status = true;
        }
        else
        {
            status = false;
        }
        return status;
    }

}
