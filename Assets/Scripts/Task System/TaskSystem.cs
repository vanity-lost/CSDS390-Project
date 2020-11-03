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

    public GameObject panel;

    float timer = 0;

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
        if (!dialogueUpdate.locked) {
            timer += Time.deltaTime;
            if (timer >= 1 && Random.Range(0,2000) == 1) {
                timer = 0f;
                int taskIndex = Random.Range(0,5);
                switch (taskIndex)
                {
                    case 4:
                        GlobalData.fuseBroken = true;
                        break;
                    case 3:
                        GlobalData.fires = true;
                        break;
                    case 2:
                        GlobalData.hullBroken = true;
                        break;
                    case 1:
                        GlobalData.engineBroken = true;
                        break;
                    case 0:
                        GlobalData.wiresBroken = true;
                        break;
                    default:
                        break;
                }
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
            Screen.lockCursor = false;
            StartCoroutine(transition("Death Scene"));
        }
        if (SubDistanceTracker.traveledDistance >= SubDistanceTracker.maxDistance) {
            ESCDectect.gameIsPaused = true;
            Screen.lockCursor = false;
            StartCoroutine(transition("End Scene"));
        }
    }

    IEnumerator transition(string sceneName) {
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
}
