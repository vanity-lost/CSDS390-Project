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
    [SerializeField] GameObject lightSwitchLocation;
    [SerializeField] GameObject lightHolder;
    [SerializeField] GameObject lightSwitch;
    [SerializeField] GameObject storage;
    [SerializeField] GameObject fireExtinguisher;
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
        Debug.Log(lights);
        Debug.Log(lights.Length);
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
                if (!GlobalData.storageLocked && engineTrigger) {
                    SceneManager.LoadScene("Fix Engine");
                }
            }
            if (Input.GetKeyDown("e") && GlobalData.wiresBroken)
            {
                if ((wireboxhead.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxhead.GetComponent<WireBoxTrigger>().getBrokenStatus())
                    ||(wireboxmid.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxmid.GetComponent<WireBoxTrigger>().getBrokenStatus())
                    ||(wireboxtail.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxtail.GetComponent<WireBoxTrigger>().getBrokenStatus()))
                {
                    SceneManager.LoadScene("Connect Wire");
                }
            }
            if (Input.GetKeyDown("e") & GlobalData.storageLocked & storage.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                SceneManager.LoadScene("Storage Room");
            }
            if (Input.GetKeyDown("e") & GlobalData.hullBroken)
            {
                SceneManager.LoadScene("Fix Hull");
            }
            if (Input.GetKeyDown("e") & GlobalData.fires & fireExtinguisher.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                SceneManager.LoadScene("Fire Extinguish");
            }
            if (Input.GetKeyDown("e") & GlobalData.fuseBroken & fuse.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                GlobalData.lights = false;
                SceneManager.LoadScene("Repair Fuse");
            }
            if (Input.GetKeyDown("n"))
            {
                SceneManager.LoadScene("End Scene");
            }
            if (Input.GetKeyDown("e") & lightSwitch.GetComponent<MinigameTrigger>().getTriggerStatus())
            {
                GlobalData.lights = !GlobalData.lights;
                Debug.Log("Lights Flipped");
                if (GlobalData.lights)
                {
                    //Debug.Log("here");
                    lightSwitch.transform.localPosition = new Vector3(-0.04849097f, 2.208767f, 2.850958f);
                    lightSwitch.transform.localRotation = new Quaternion(-0.000583283196f, 0.197512761f, -0.00289495266f, 0.980295897f);
                    //Quaternion(-0.000583283196, 0.197512761, -0.00289495266, 0.980295897);
                }
                else
                {
                    lightSwitch.transform.localPosition = new Vector3(0.3853737f, 1.660247f, 2.669332f);
                    lightSwitch.transform.localRotation = new Quaternion(-0.166412354f, 0.106388971f, -0.82593739f, 0.528030097f);
                }
            }
        }
        timer += Time.deltaTime;
        /*Debug.Log("Lights " + GlobalData.lightsOn);
        Debug.Log("Switch " + GlobalData.lights);
        Debug.Log("Wires " + GlobalData.wiresBroken);
        Debug.Log("Fuses " +GlobalData.fuseBroken);
        */
        if (GlobalData.lightsOn != (GlobalData.lights & !GlobalData.wiresBroken & !GlobalData.fuseBroken))
        {
            /*
            Debug.Log("Switch Light Setting");
            Debug.Log(GlobalData.lightsOn);
            Debug.Log(GlobalData.lights);
            Debug.Log(GlobalData.wiresBroken);
            Debug.Log(GlobalData.fuseBroken);
            */
            GlobalData.lightsOn = !GlobalData.lightsOn;
            LightsFlip();
        }
        //Engines breaks at 30 seconds
        if (timer > 5 && GlobalData.updateEngine == false) 
        {
            Debug.Log("Broke Engine");
            GlobalData.updateEngine = true;
            GlobalData.engineBroken = true;
        }
        //Fires occur at 60 seconds
        if (timer > 10 && GlobalData.updateFire == false)
        {
            Debug.Log("Fire");
            FireEffect.SetActive(true);
            GlobalData.updateFire = true;
            GlobalData.fires = true;
        }
        if (!GlobalData.updateFire) {
            FireEffect.SetActive(false);
        }
        //Wires break at 90 seconds
        if (timer > 15 && GlobalData.updateWires == false)
        {
            Debug.Log("Broke Wires");
            GlobalData.updateWires= true;
            GlobalData.wiresBroken = true;
            int ranNum = UnityEngine.Random.Range(1, 4);
            if (ranNum == 1)
            {
                wireboxhead.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("head one broken");
            }
            if (ranNum == 2)
            {
                wireboxmid.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("mid one broken");
            }
            if (ranNum == 3)
            {
                wireboxtail.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
                Debug.Log("tail one broken");
            }
            if(ranNum == 4)
            {
                Debug.Log("Wire broken with ranNum 4");
            }


        }
        //Hull break at 120 seconds
        if (timer > 20 && GlobalData.updateHull == false)
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


    /*
    public void FuseBroken(bool status)
    {
        fuseBroken = status;
    }

    public void EngineBroken(bool status)
    {
        engineBroken = status;
    }

    public void Fires(bool status)
    {
        fires = status;
    }

    public void HullBroken(bool status)
    {
        fuseBroken = status;
    }

    public void WiresBroken(bool status)
    {
        fuseBroken = status;
    }

    public void StorageLocked(bool status)
    {
        storageLocked = status;
    }
    */


}
