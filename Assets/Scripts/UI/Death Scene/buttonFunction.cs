using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    public void loadStart()
    {
        energy.energyNum = 100;
        SubHealth.healthNum = 100;
        SubDistanceTracker.traveledDistance = 0;
        GlobalData.lightSwitch = true;
        GlobalData.lightsOn = true;
        GlobalData.engineBroken = false;
        GlobalData.wiresBroken = false;
        GlobalData.hullBroken = false;
        GlobalData.fuseBroken = false;
        GlobalData.engineOn = true;
        GlobalData.radarOn = true;
        GlobalData.updateEngine = false;
        GlobalData.updateFire = false;
        GlobalData.updateWires = false;
        GlobalData.updateHull = false;
        ESCDectect.gameIsPaused = false;
        Screen.lockCursor = true;
        SceneManager.LoadScene("Start Scene");
    }

    public void loadMain()
    {
        energy.energyNum = 100;
        SubHealth.healthNum = 100;
        SubDistanceTracker.traveledDistance = 0;
        GlobalData.lightSwitch = true;
        GlobalData.lightsOn = true;
        GlobalData.engineBroken = false;
        GlobalData.wiresBroken = false;
        GlobalData.hullBroken = false;
        GlobalData.fuseBroken = false;
        GlobalData.engineOn = true;
        GlobalData.radarOn = true;
        GlobalData.updateEngine = false;
        GlobalData.updateFire = false;
        GlobalData.updateWires = false;
        GlobalData.updateHull = false;
        ESCDectect.gameIsPaused = false;
        Screen.lockCursor = true;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game exited!");
    }
}
