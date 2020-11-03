using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] GameObject wireboxhead;
    [SerializeField] GameObject wireboxmid;
    [SerializeField] GameObject wireboxtail;
    [SerializeField] GameObject engine;
    [SerializeField] GameObject fuse;
    [SerializeField] GameObject lightHolder;
    [SerializeField] GameObject lightSwitch;
    [SerializeField] GameObject hull;
    [SerializeField] GameObject storage;
    [SerializeField] GameObject fireExtinguisher;

    [SerializeField] GameObject radarConsole;
    [SerializeField] Light[] lights;
    [SerializeField] float distance = 5f;

    public GameObject storageHint;
    public GameObject FireEffect;
    private bool engineUpdate = false;
    public float timer = 0f;
    public static bool engineTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        //GlobalData.fuseBroken = true;
        //GlobalData.lights = true;
        //GlobalData.lightsOn = true;
        lights = lightHolder.GetComponentsInChildren<Light>();
        //Debug.Log(lights);
        //Debug.Log(lights.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wirebox.GetComponent<WireBoxTrigger>().getStatus());
        if (!dialogueUpdate.locked) {
            if (Input.GetKeyDown("e") && engine.GetComponent<MinigameTrigger>().getTriggerStatus() && GlobalData.engineBroken)
            {
                if (GlobalData.storageLocked) {
                    storageHint.SetActive(true);
                    TaskSystem.hint = true;
                }
                else{
                    ESCDectect.gameIsPaused = true;
                    SceneManager.LoadScene("Fix Engine");
                    //if (engineTrigger)
                    //{
                    //    SceneManager.LoadScene("Fix Engine");
                    //}

                }
            }
            // if the engine is not broken, can be silenced anytime TODO make engine silence fit desired behavior (outside cant attack etc)
            else if (Input.GetKeyDown("e") && engine.GetComponent<MinigameTrigger>().getTriggerStatus() && GlobalData.engineOn) 
            {
                SceneManager.LoadScene("SilenceEngine");
            }
            if (Input.GetKeyDown("e") && radarConsole.GetComponent<MinigameTrigger>().getTriggerStatus() && GlobalData.radarOn) 
            {
                SceneManager.LoadScene("Sonor On Off");
            }
            if (Input.GetKeyDown("e") && GlobalData.wiresBroken)
            {
                if ((wireboxhead.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxhead.GetComponent<WireBoxTrigger>().getBrokenStatus())
                    ||(wireboxmid.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxmid.GetComponent<WireBoxTrigger>().getBrokenStatus())
                    ||(wireboxtail.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxtail.GetComponent<WireBoxTrigger>().getBrokenStatus()))
                {
                    ESCDectect.gameIsPaused = true;
                    SceneManager.LoadScene("Connect Wire");
                }
            }
            if (Input.GetKeyDown("e") & GlobalData.storageLocked & storage.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Storage Room");
            }
            if (Input.GetKeyDown("e") & GlobalData.hullBroken && hull.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Fix Hull");
            }
            if (Input.GetKeyDown("e") & GlobalData.fires & fireExtinguisher.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Fire Extinguish");
            }
            if (Input.GetKeyDown("e") & GlobalData.fuseBroken & fuse.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                //GlobalData.lightsOn = false;
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Repair Fuse");
            }
            if (Input.GetKeyDown("e") & lightSwitch.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                Debug.Log(GlobalData.lightSwitch);
                GlobalData.lightSwitch = !GlobalData.lightSwitch;
                Debug.Log("Lights Flipped");
                Debug.Log(GlobalData.lightSwitch);
            }
        }
        timer += Time.deltaTime;
        //Debug.Log(GlobalData.lightSwitch);
        if (GlobalData.lightsOn != lights[0].enabled)
        {
            GlobalData.lightsOn = !GlobalData.lightsOn;
        }
            if (GlobalData.lightsOn != (GlobalData.lightSwitch && !GlobalData.wiresBroken && !GlobalData.fuseBroken))
        {
                Debug.Log("In Here");
                GlobalData.lightsOn = !GlobalData.lightsOn;
                LightsFlip();
        }
        //Debug.Log(GlobalData.lightSwitch);
        if (GlobalData.lightSwitch)
        {
            lightSwitch.transform.localPosition = new Vector3(-0.04849097f, 2.208767f, 2.850958f);
            lightSwitch.transform.localRotation = new Quaternion(-0.000583283196f, 0.197512761f, -0.00289495266f, 0.980295897f);
        }
        else
        {
            lightSwitch.transform.localPosition = new Vector3(0.3853737f, 1.660247f, 2.669332f);
            lightSwitch.transform.localRotation = new Quaternion(-0.166412354f, 0.106388971f, -0.82593739f, 0.528030097f);
        }
        //Engines breaks at 30 seconds
        if (GlobalData.updateEngine == false) 
        {
            Debug.Log("Broke Engine");
            GlobalData.updateEngine = true;
            GlobalData.engineBroken = true;
        }
        //Fires occur at 60 seconds
        if (GlobalData.updateFire == false)
        {
            Debug.Log("Fire");
            //FireEffect.SetActive(true);
            GlobalData.updateFire = true;
            GlobalData.fires = true;
        }
        if (!GlobalData.fires) {
            FireEffect.SetActive(false);
        }
        else
        {
            FireEffect.SetActive(true);
        }
        if (!GlobalData.hullBroken)
        {
            hull.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
        else
        {
            hull.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
        //Wires break at 90 seconds
        if ((GlobalData.updateWires == false) || GlobalData.wiresBroken)
        {
            Debug.Log("Broke Wires");
            GlobalData.updateWires= true;
            GlobalData.wiresBroken = true;
            //int ranNum = UnityEngine.Random.Range(1, 4);
            //GlobalData.brokenWireboxLoc = ranNum;
            Debug.Log("global datat brokwn wire box loc = " + GlobalData.brokenWireboxLoc);
            if (GlobalData.brokenWireboxLoc == 1)
            {
                wireboxhead.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("head one broken");
            }
            if (GlobalData.brokenWireboxLoc == 2)
            {
                wireboxmid.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("mid one broken");
            }
            if (GlobalData.brokenWireboxLoc == 3)
            {
                wireboxtail.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("tail one broken");
            }
            if(GlobalData.brokenWireboxLoc == 4)
            {
                Debug.Log("Wire broken with ranNum 4");
            }


        }
        //Hull break at 120 seconds
        if (GlobalData.updateHull == false)
        {
            Debug.Log("Broke Hull");
            GlobalData.updateHull = true;
            GlobalData.hullBroken = true;
        }

    }
    

    public void LightsFlip()
    {
        foreach (Light child in lights)
        {
            Light light = child.GetComponent<Light>();
            light.enabled = !light.enabled;
        }
    }


}
