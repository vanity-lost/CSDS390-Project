using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutdoorEnemy : MonoBehaviour
{
    public bool attack = false;

    public IEnumerator Move(Vector3 monster, Vector3 target, float speed)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (Vector3.Distance(monster, target) < 6.0f)
        {
            attack = true;
            //TempOutdoorCreature.monsterStop = true;
            //TempOutdoorCreature.Attack();
        }
        yield return 0;
    }
}
