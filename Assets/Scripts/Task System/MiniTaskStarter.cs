using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniTaskStarter : MonoBehaviour
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

    [SerializeField] Light[] lights;
    [SerializeField] float distance = 5f;

    public GameObject EngineRoomSpotter;
    public GameObject StorageRoomSpotter;
    public GameObject WireHeadSpotter;
    public GameObject WireMidSpotter;
    public GameObject WireLowSpotter;
    public GameObject HullSpotter;
    public GameObject FuseSpotter;
    public GameObject FireSpotter;


    public GameObject storageHint;
    public GameObject FireEffect;
    private bool engineUpdate = false;
    public static bool engineTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        if (GlobalData.position.Equals(new Vector3(0, -10f, 0))) {
            GlobalData.position = transform.position;
        } else {
            transform.position = GlobalData.position;
        }
        if (GlobalData.rotation==(new Quaternion(1, 0, 0, 1))) {
            GlobalData.rotation = transform.rotation;
        } else {
            transform.rotation = GlobalData.rotation;
        }
        lights = lightHolder.GetComponentsInChildren<Light>();
    }

    void Update()
    {
        GlobalData.position = transform.position;
        GlobalData.rotation = transform.rotation;
        if(GlobalData.engineBroken) {
            EngineRoomSpotter.SetActive(true);
            engine.transform.GetComponent<AudioSource>().Stop();
            if (Input.GetKeyDown("e") && engine.GetComponent<MinigameTrigger>().getTriggerStatus() && GlobalData.engineBroken && GlobalData.storageLocked == false) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Fix Engine");
            }
        } else {
            if (engine.transform.GetComponent<AudioSource>().isPlaying == false)
            {
                engine.transform.GetComponent<AudioSource>().Play();
                engine.transform.GetComponent<AudioSource>().loop = true;
            }
            EngineRoomSpotter.SetActive(false);
        }

        if(GlobalData.wiresBroken) {
            if (GlobalData.brokenWireboxLoc == 1  && !wireboxtail.GetComponent<WireBoxTrigger>().getBrokenStatus() && !wireboxmid.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                setWireBoxSpotter(1);
                wireboxhead.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
            }
            else if (GlobalData.brokenWireboxLoc == 2 && !wireboxhead.GetComponent<WireBoxTrigger>().getBrokenStatus() && !wireboxtail.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                setWireBoxSpotter(2);
                wireboxmid.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
            }
            else if (GlobalData.brokenWireboxLoc == 3 && !wireboxhead.GetComponent<WireBoxTrigger>().getBrokenStatus() && !wireboxmid.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                setWireBoxSpotter(3);
                wireboxtail.GetComponent<WireBoxTrigger>().setBrokenStatus(true);
            }

            if (Input.GetKeyDown("e") && wireboxhead.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxhead.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Connect Wire");
            } else if(Input.GetKeyDown("e") && wireboxmid.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxmid.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Connect Wire");
            } else if(Input.GetKeyDown("e") && wireboxtail.GetComponent<WireBoxTrigger>().getTriggerStatus() && wireboxtail.GetComponent<WireBoxTrigger>().getBrokenStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Connect Wire");
            }
        } else {
            WireHeadSpotter.SetActive(false);
            wireboxhead.GetComponent<WireBoxTrigger>().setBrokenStatus(false);

            WireMidSpotter.SetActive(false);
            wireboxmid.GetComponent<WireBoxTrigger>().setBrokenStatus(false);

            WireLowSpotter.SetActive(false);
            wireboxtail.GetComponent<WireBoxTrigger>().setBrokenStatus(false);
        }

        if (GlobalData.storageLocked ) {
            StorageRoomSpotter.SetActive(true);
            if(Input.GetKeyDown("e") & storage.GetComponent<MinigameTrigger>().getTriggerStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Storage Room");
            }
        } else {
            StorageRoomSpotter.SetActive(false);
        }

        if(GlobalData.hullBroken) {
            HullSpotter.SetActive(true);
            if (Input.GetKeyDown("e") && hull.GetComponent<MinigameTrigger>().getTriggerStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Fix Hull");
            }
        } else {
            HullSpotter.SetActive(false);
        }

        if(GlobalData.fires) {
            FireEffect.SetActive(true);
            FireSpotter.SetActive(true);
            if (Input.GetKeyDown("e") & fireExtinguisher.GetComponent<MinigameTrigger>().getTriggerStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Fire Extinguish");
            }
        } else {
            FireEffect.SetActive(false);
            FireSpotter.SetActive(false);
        }

        if(GlobalData.fuseBroken) {
            FuseSpotter.SetActive(true);
            if (Input.GetKeyDown("e") & fuse.GetComponent<MinigameTrigger>().getTriggerStatus()) {
                ESCDectect.gameIsPaused = true;
                SceneManager.LoadScene("Repair Fuse");
            }
        } else {
            FuseSpotter.SetActive(false);
        }

        if (Input.GetKeyDown("e") & lightSwitch.GetComponent<MinigameTrigger>().getTriggerStatus())
        {
            lightSwitch.GetComponent<AudioSource>().time = 0.5f;
            lightSwitch.GetComponent<AudioSource>().Play();
            Debug.Log(GlobalData.lightSwitch);
            GlobalData.lightSwitch = !GlobalData.lightSwitch;
            Debug.Log("Lights Flipped");
            Debug.Log(GlobalData.lightSwitch);
        }
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
        if (!GlobalData.hullBroken)
        {
            hull.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
        else
        {
            hull.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
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

    public void setWireBoxSpotter(int index) {
        switch(index) {
            case 1:
            WireHeadSpotter.SetActive(true);
            WireMidSpotter.SetActive(false);
            WireLowSpotter.SetActive(false);
            break;
            case 2:
            WireHeadSpotter.SetActive(false);
            WireMidSpotter.SetActive(true);
            WireLowSpotter.SetActive(false);
            break;
            case 3:
            WireHeadSpotter.SetActive(false);
            WireMidSpotter.SetActive(false);
            WireLowSpotter.SetActive(true);
            break;
        }
    }
}
