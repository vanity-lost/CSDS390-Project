using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TaskSystem : MonoBehaviour
{
    public TextMeshProUGUI _dialogue;
    private string title;
    private string taskInfo = "";
    public GameObject newTaskHint;
    public static bool hint = false;

    public AudioMixer mixer;

    float timer = 0;
    float timer2 = 0;

    bool triggerFire = false;
    bool triggerEngine = false;
    bool triggerFuse = false;
    bool triggerWire = false;

    // Start is called before the first frame update
    void Start()
    {
        title = "Tasks\n------------------------------\n";
        _dialogue.SetText(taskInfo);
        mixer.SetFloat("MusicVol", Mathf.Log10(0.5f)*20);
    }

    // Update is called once per frame
    void Update()
    {   
        if (!GlobalData.hullBroken) {
            timer2 = 0;
            triggerFire = false;
            triggerEngine = false;
            triggerFuse = false;
            triggerWire = false;
            timer += Time.deltaTime;
        }
        if (timer >= 20) {
            if (Random.Range(0,5) == 1) {
                timer = 0;
                GlobalData.hullBroken = true;
                GlobalData.updateHull = true;
            }
        }
        if (GlobalData.hullBroken) {
            timer2 += Time.deltaTime;
            if (timer2 > 10 && !triggerFire) {
                triggerFire = true;
                GlobalData.fires = true;
                GlobalData.updateFire = true;
            }
            if (timer2 > 15 && Random.Range(0,10) == 1 && !triggerEngine) {
                triggerEngine = true;
                GlobalData.engineBroken = true;
                GlobalData.updateEngine = true;
            }
            if (timer2 > 30 && Random.Range(0,10) == 1 && !triggerFuse) {
                triggerFuse = true;
                GlobalData.fuseBroken = true;
            }
            if (timer2 > 30 && Random.Range(0,10) == 1 && !triggerWire) {
                triggerWire = true;
                GlobalData.wiresBroken = true;
                GlobalData.updateWires = true;
            }
        }

        taskInfo = title;
        SubDistanceTracker.isMoving = true;
        if (hint) {
            taskInfo += "-    The storage closet may have a wrench. Have a look!!\n";
            newTaskHint.SetActive(true);
        }

        if (GlobalData.storageLocked)
        {
            taskInfo += "-    Storage Locked!\n";
            newTaskHint.SetActive(true);
            SubDistanceTracker.isMoving = false;  
            //hint = false;
        } 

        if (GlobalData.engineBroken) {
            taskInfo += "-    Engine Broken!\n";
            newTaskHint.SetActive(true);
            SubDistanceTracker.isMoving = false;      
        } 

        if (GlobalData.fires) {
            taskInfo += "-    Fires in the submarine!\n";
            newTaskHint.SetActive(true);
            SubHealth.healthNum -= Time.deltaTime * 0.2f;
        }

        if (GlobalData.wiresBroken) {
            taskInfo += "-    Wires Broken!\n";
            newTaskHint.SetActive(true);
            //GlobalData.lightsOn = false;
            energy.energyNum -= Time.deltaTime * 0.2f;
        }

        if (GlobalData.hullBroken) {
            taskInfo += "-    Hull Broken!\n";
            newTaskHint.SetActive(true);
            SubHealth.healthNum -= Time.deltaTime * 0.5f;
        }

        if (GlobalData.fuseBroken) {
            taskInfo += "-    Something wrong in the fuse!\n";
            newTaskHint.SetActive(true);
            //GlobalData.lightsOn = false;
        }

        if (!GlobalData.engineBroken && !GlobalData.wiresBroken && !GlobalData.hullBroken && !GlobalData.fires && !GlobalData.fuseBroken && !GlobalData.storageLocked) {
            newTaskHint.SetActive(false);
        }
        
        _dialogue.SetText(taskInfo);

        if (energy.energyNum <= 0 || SubHealth.healthNum <= 0) {
            ESCDectect.gameIsPaused = true;
            SceneManager.LoadScene("Death Scene");
        }
        if (SubDistanceTracker.traveledDistance == SubDistanceTracker.maxDistance) {
            ESCDectect.gameIsPaused = true;
            SceneManager.LoadScene("End Scene");
        }
    }

}
