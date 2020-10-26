using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public float MENACE_START = 100000.0f;
    [SerializeField] static public float menaceMeter = 100000.0f; 

    void Start() {
        menaceMeter = MENACE_START;
    }
    // Update is called once per frame
    void Update()
    {
        menaceMeter -= Time.deltaTime;
        int miniTask = Random.Range(0, (int)menaceMeter);
        if(miniTask >= 0 && miniTask <= 5 && !getTask(miniTask)) {
            setTask(miniTask);
        }

        if((int)menaceMeter == 5) {
            menaceMeter = MENACE_START;
        } 
    }

    public bool getTask(int index) {
        switch (index)
        {
        case 6: 
            break;
        case 5:
            return GlobalData.fuseBroken;
            break;
        case 4:
            return GlobalData.fires;
            break;
        case 3:
            return GlobalData.hullBroken;
            break;
        case 2:
            return GlobalData.engineBroken;
            break;
        case 1:
            return GlobalData.storageLocked;
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
        case 6: 
            break;
        case 5:
            GlobalData.fuseBroken = true;
            break;
        case 4:
            GlobalData.fires = true;
            break;
        case 3:
            GlobalData.hullBroken = true;
            break;
        case 2:
            GlobalData.engineBroken = true;
            break;
        case 1:
            //GlobalData.storageLocked = true;
            break;
        case 0:
            GlobalData.wiresBroken = true;
            break;
        default:
            Debug.Log("Incorrect index");
            break;
        }
    }
    
}

