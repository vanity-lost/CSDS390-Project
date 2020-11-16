using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOutdoorCreature : MonoBehaviour
{
    [SerializeField] public GameObject monster;
    [SerializeField] public CameraShake periscopeCamera;
    [SerializeField] public CameraShake mainCamera;
    [SerializeField] public MoveOutdoorEnemy moveMonster;
    [SerializeField] public GameObject boom1;
    [SerializeField] public GameObject boom2;
    [SerializeField] public GameObject boom3;

    public static Vector3 subVector = new Vector3();
    public static Vector3 monsterVector;

    private float speed = 6.0f;
    private float subDistance = 0.0f;
    private float saveDistance = 0.0f;

    private bool reset = false;
    public bool isAttacking = false;
    public bool monsterStop = false;
    public static bool monsterStatus = false;

    System.Random random = new System.Random();

    void Awake()
    {
        subVector = GameObject.Find("Submarine").transform.position;
        Debug.Log("monster status: " + monsterStatus);
        if (monsterStatus)
        {
            monster.SetActive(true);
            monster.transform.position = monsterVector;
        }
    }

    //void Start()
    //{
    //    monster.transform.position = monsterVector;
    //}

    void Update()
    {
        //if (!monsterStatus)
        //{
        //    MonsterAppear();
        //}
        MonsterAppear();
        if (monsterStatus && !monsterStop)
        {
            StartCoroutine(moveMonster.Move(monsterVector, subVector, speed));
            FindMonster();
            bool canAttack = MonsterCanAttack();
            if (canAttack)
            {
                monsterStop = true;
                saveDistance = subDistance;
                StartCoroutine(Attack());
            }
            else
            {
                FindMonster();
                if (Vector3.Distance(monsterVector, subVector) < 5.0f)
                {
                    ResetMonster();
                }
            }
        }
    }

    bool MonsterCanAttack()
    {
        bool distance = moveMonster.attack;
        bool lights = CheckLights();
        bool radar = CheckRadar();
        bool status = false;
        if (distance && lights)
        {
            status = true;
        }
        else if (distance && radar)
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
                //case 0.0f:
                //    SpawnMonster();
                //    FindMonster();
                //    monsterStatus = true;
                //    break;
                case 20.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                //case 100.0f:
                //    SpawnMonster();
                //    FindMonster();
                //    monsterStatus = true;
                //    break;
                case 170.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 250.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 330.0f:
                    SpawnMonster();
                    FindMonster();
                    monsterStatus = true;
                    break;
                case 420.0f:
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

    public void FindMonster()
    {
        monsterVector = monster.transform.position;
    }

    void SpawnMonster()
    {
        int randX = random.Next(-120, -80);
        int randY = random.Next(40, 60);
        int randZ = random.Next(100, 140);
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
        int numAttacks = 0;
        int soundIndex = 0;

        isAttacking = true;
        while (canAttack && numAttacks < 3)
        {
            SubHealth.monsterAttack++;
            numAttacks++;
            GlobalData.hullBroken = true;
            StartCoroutine(periscopeCamera.Shake(0.15f, 0.4f));
            StartCoroutine(mainCamera.Shake(0.15f, 0.4f));
            Debug.Log("number of attacks: " + numAttacks);
            soundIndex++;
            switch (soundIndex)
            {
                case 1:
                    boom1.SetActive(true);
                    break;
                case 2:
                    boom2.SetActive(true);
                    break;
                case 3:
                    boom3.SetActive(true);
                    break;
            }

            if (numAttacks < 3)
            {
                yield return new WaitForSeconds(5);
            }
            if (numAttacks == 3)
            {
                yield return new WaitForSeconds(2);
            }
            boom1.SetActive(false);
            boom2.SetActive(false);
            boom3.SetActive(false);
            canAttack = MonsterCanAttack();
        }
        //SubHealth.monsterAttack++;
        //numAttacks++;
        //GlobalData.hullBroken = true;
        //StartCoroutine(periscopeCamera.Shake(0.15f, 0.4f));
        //StartCoroutine(mainCamera.Shake(0.15f, 0.4f));
        //Debug.Log("number of attacks: " + numAttacks);
        //Debug.Log("lights on: " + lightsOn);
        //while (canAttack && numAttacks < 3)
        //{
        //    elapsedTime += Time.deltaTime;
        //    Debug.Log("elapsed time: " + elapsedTime);
        //    if (elapsedTime >= 10.0f)
        //    {
        //        SubHealth.monsterAttack++;
        //        numAttacks++;
        //        Debug.Log("number of attacks: " + numAttacks);
        //        StartCoroutine(periscopeCamera.Shake(0.15f, 0.4f));
        //        StartCoroutine(mainCamera.Shake(0.15f, 0.4f));
        //        yield return new WaitForSeconds(5);
        //        Debug.Log("waited for 5 seconds");
        //        elapsedTime = 0;
        //    }
        //    canAttack = MonsterCanAttack();
        //}
        soundIndex = 0;
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
        monsterStatus = false;
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

    //public static void GetMonsterLocation()
    //{
    //    monsterVector = monster.transform.position;
    //}

}
