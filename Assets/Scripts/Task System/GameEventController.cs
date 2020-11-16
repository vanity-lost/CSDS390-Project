using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public float MENACE_START = 2000.0f;
    [SerializeField] static public float menaceMeter = 10000.0f; 
    static float timer = 0;
    static List<int> shuffleList;
    static bool shuffleTasks = true;
    static int index = 0;
    public int NUM_TASKS = 4;

    void Start() {
        menaceMeter = GlobalData.MENACE_METER;
        if(dialogueUpdate.locked) shuffleList =  generateShuffleList(NUM_TASKS);
    }
    // Update is called once per frame
    void Update()
    {
        if(!dialogueUpdate.locked && !GlobalData.storageLocked) {
            menaceMeter -= Time.deltaTime * 0.1f; //0.1
            int miniTask = Random.Range(0, (int)menaceMeter);

            timer += Time.deltaTime;
            if (timer > 5) {
                if (miniTask >= 0 && miniTask <= NUM_TASKS && index < shuffleList.Count && !getTask(shuffleList[index]) && shuffleTasks) {
                    setTask(shuffleList[index]);
                    index++;
                    timer = 0; //0
                }
            }

            if(index == NUM_TASKS) {
                //Debug.Log("current index just reached the list Size: " + index );
                shuffleList = generateShuffleList(NUM_TASKS);
                index = 0;
                shuffleTasks = false;
            }

            if(GlobalData.numTasksFinished == NUM_TASKS) {
                //Debug.Log("Max Tasks Reached");
                shuffleTasks = true;
                GlobalData.numTasksFinished = 0;
            }

            if((int)menaceMeter == NUM_TASKS) {
                menaceMeter = MENACE_START;
            } 
        }    

    //Debug.Log("Number of tasks done: " +  GlobalData.numTasksFinished);
    //Debug.Log("current index: " + index );
    //Debug.Log(string.Join("; ", shuffleList));
        
    }

    public bool getTask(int index) {
        switch (index)
        {
        case 3:
            return GlobalData.fuseBroken;
            break;
        case 2:
            return GlobalData.fires;
            break;
        case 1:
            return GlobalData.engineBroken;
            break;
        case 0:
            return GlobalData.wiresBroken;
            break;
        default:
            return false;
            break;
        }

        return false;
    }

    public void setTask(int index) {
        switch (index)
        {
        case 3:
            // so that the lights do not go out when the outside monster is spawned
            Debug.Log("check if monster is spawned: " + TempOutdoorCreature.monsterStatus);
            if (!TempOutdoorCreature.monsterStatus)
            {
                GlobalData.fuseBroken = true;
            }
            break;
        case 2:
            GlobalData.fires = true;
            break;
        case 1:
            GlobalData.engineBroken = true;
            break;
        case 0:
            // so that the lights do not go out when the outside monster is spawned
            Debug.Log("check if monster is spawned: " + TempOutdoorCreature.monsterStatus);
            if (!TempOutdoorCreature.monsterStatus)
            {
                GlobalData.brokenWireboxLoc = Random.Range(1, 4);
                GlobalData.wiresBroken = true;
            }
            break;
        default:
            Debug.Log("Incorrect index");
            break;
        }
    }

    public List<int> generateShuffleList(int listSize) {
        List<int> numberList = new List<int>();
        int number;

        for (int i = 0; i < listSize; i++)
        {
            do {
                number = Random.Range(0, listSize);
            } while (numberList.Contains(number));
            numberList.Add(number);
        }

        return numberList;
    }
    
}

