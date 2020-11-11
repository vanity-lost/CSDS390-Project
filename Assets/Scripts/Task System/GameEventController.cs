using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public float MENACE_START = 10000.0f;
    [SerializeField] static public float menaceMeter = 10000.0f; 
    float timer;

    void Start() {
        menaceMeter = MENACE_START;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!dialogueUpdate.locked) {
            menaceMeter -= Time.deltaTime * 0.2f; //0.1
            int miniTask = Random.Range(0, (int)menaceMeter);

            timer += Time.deltaTime;
            if (timer > 1) {
                if (miniTask >= 0 && miniTask <= 4 && !getTask(miniTask)) {
                    setTask(miniTask);
                    timer = 0; //0
                }
            }

            if((int)menaceMeter == 5) {
                menaceMeter = MENACE_START;
            } 
        }    
    }

    public bool getTask(int index) {
        switch (index)
        {
        case 4:
            return GlobalData.fuseBroken;
            break;
        case 3:
            return GlobalData.fires;
            break;
        case 2:
            return GlobalData.hullBroken;
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
        case 4:
            GlobalData.fuseBroken = true;
            break;
        case 3:
            GlobalData.fires = true;
            break;
        case 2:
            //GlobalData.hullBroken = true;
            break;
        case 1:
            GlobalData.engineBroken = true;
            break;
        case 0:
            GlobalData.brokenWireboxLoc = Random.Range(1, 4);
            GlobalData.wiresBroken = true;
            break;
        default:
            Debug.Log("Incorrect index");
            break;
        }
    }
    
}

