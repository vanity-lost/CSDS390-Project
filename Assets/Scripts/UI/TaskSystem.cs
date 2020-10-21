using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskSystem : MonoBehaviour
{
    public TextMeshProUGUI _dialogue;
    private string title;
    private string taskInfo = "";
    public GameObject newTaskHint;
    public static bool hint = false;

    // Start is called before the first frame update
    void Start()
    {
        title = "Tasks\n------------------------------\n";
        _dialogue.SetText(taskInfo);
    }

    // Update is called once per frame
    void Update()
    {   
        taskInfo = title;
        GlobalData.lights = true;
        SubDistanceTracker.isMoving = true;
        if (hint) {
            taskInfo += "-    The storage closet may have a wrench. Have a look!!\n";
            newTaskHint.SetActive(true);
        }
        if (!GlobalData.storageLocked)
        {
            hint = false;
        }

        if (GlobalData.engineBroken && GlobalData.updateEngine) {
            taskInfo += "-    Engine Broken!\n";
            newTaskHint.SetActive(true);
            SubDistanceTracker.isMoving = false;
        }
        if (GlobalData.fires && GlobalData.updateFire) {
            taskInfo += "-    Fires in the submarine!\n";
            newTaskHint.SetActive(true);
            SubHealth.healthNum -= Time.deltaTime * 2f;
        }
        if (GlobalData.wiresBroken && GlobalData.updateWires) {
            taskInfo += "-    Wires Broken!\n";
            newTaskHint.SetActive(true);
            GlobalData.lights = false;
            energy.energyNum -= Time.deltaTime * 0.5f;
        }
        if (GlobalData.hullBroken && GlobalData.updateHull) {
            taskInfo += "-    Hull Broken!\n";
            newTaskHint.SetActive(true);
            SubHealth.healthNum -= Time.deltaTime * 2f;
        }
        if (GlobalData.fuseBroken) {
            taskInfo += "-    Something wrong in the fuse!\n";
            newTaskHint.SetActive(true);
            GlobalData.lights = false;
        }
        if (!GlobalData.engineBroken && !GlobalData.wiresBroken && !GlobalData.hullBroken && !GlobalData.fires && !GlobalData.fuseBroken && !GlobalData.storageLocked) {
            newTaskHint.SetActive(false);
        }
        _dialogue.SetText(taskInfo);
    }
}
