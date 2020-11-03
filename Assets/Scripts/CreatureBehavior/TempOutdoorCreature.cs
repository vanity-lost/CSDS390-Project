using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOutdoorCreature : MonoBehaviour
{

    public GameObject monster;

    void Update()
    {
        MonsterAppear();
    }

    private void MonsterAppear()
    {
        if (Time.time > 2)
        {
            monster.SetActive(true);

            Vector3 subVector = GameObject.Find("Submarine").transform.position;
            Vector3 monsterVector = GameObject.Find("Monster").transform.position;

            while (subVector != monsterVector)
            {
                monsterVector = Vector3.MoveTowards(monsterVector, subVector, 10.0f);

            }
        }
    }
}
