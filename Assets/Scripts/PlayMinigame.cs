using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMinigame : MonoBehaviour
{
    Text instruction;
    [SerializeField] GameObject wirebox;
    [SerializeField] GameObject engine;
    [SerializeField] float distance = 5f;

    [SerializeField] private bool engineBroken = false;
    [SerializeField] private bool wiresBroken = false;
    [SerializeField] private bool hullBroken = false;
    [SerializeField] private bool fires = false;
    [SerializeField] private bool fuseBroken = false;
    [SerializeField] private bool storageLocked = false;

    private bool engineUpdate = false;

    // Start is called before the first frame update
    void Start()
    {
        engineBroken = true;
        fuseBroken = true;
        instruction = GameObject.Find("Text").GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wirebox.GetComponent<WireBoxTrigger>().getStatus());
        if (!dialogueUpdate.locked) {
            if (Input.GetKeyDown("q") & (Vector3.Distance(transform.position, engine.transform.position) < distance) & GlobalData.engineBroken)
            {
                SceneManager.LoadScene("Fix Engine");
            }
            if (Input.GetKeyDown("l") && GlobalData.wiresBroken && wirebox.GetComponent<WireBoxTrigger>().getStatus())
            {
                SceneManager.LoadScene("Connect Wire");
            }
            /**if (wirebox.GetComponent<WireBoxTrigger>().getStatus() && Input.GetKeyDown("f")) 
            {
                SceneManager.LoadScene("Connect Wire");
            }**/
            if (Input.GetKeyDown("k") & GlobalData.storageLocked)
            {
                SceneManager.LoadScene("Storage Room");
            }
            if (Input.GetKeyDown("h") & GlobalData.hullBroken)
            {
                SceneManager.LoadScene("Fix Hull");
            }
            if (Input.GetKeyDown("o") & GlobalData.fires)
            {
                SceneManager.LoadScene("Fire Extinguish");
            }
            if (Input.GetKeyDown("f") & GlobalData.fuseBroken)
            {
                SceneManager.LoadScene("Repair Fuse");
            }
            if (Input.GetKeyDown("n"))
            {
                SceneManager.LoadScene("End Scene");
            }
        }
        //Engines breaks at 30 seconds
        if (Time.time > 30 &  GlobalData.updateEngine == false) 
        {
            Debug.Log("Broke Engine");
            instruction.text="Fix the Broken Engine - Press 'q'";
            GlobalData.updateEngine = true;
            GlobalData.engineBroken = true;
        }
        //Fires occur at 60 seconds
        if (Time.time > 60 & GlobalData.updateFire == false)
        {
            Debug.Log("Fire");
            instruction.text="There's a fire go and Extinguish it - Press 'o'";
            GlobalData.updateFire = true;
            GlobalData.fires = true;
        }
        //Wires break at 90 seconds
        if (Time.time > 90 & GlobalData.updateWires == false)
        {
            Debug.Log("Broke Wires");
            instruction.text="Wires are Broken, go fix them - Press 'l'";
            GlobalData.updateWires= true;
            GlobalData.wiresBroken = true;
        }
        //Hull break at 120 seconds
        if (Time.time > 120 & GlobalData.updateHull == false)
        {
            Debug.Log("Broke Hull");
            instruction.text="The Hull is broken, go check it out - Press 'h'";
            GlobalData.updateHull = true;
            GlobalData.hullBroken = true;
        }
        //Hull break at 120 seconds
        if (Time.time > 150 & GlobalData.updateStorage == false)
        {
            Debug.Log("Storage Locked");
            instruction.text="The storage is locked, go and open it - Press 'k'";
            GlobalData.updateStorage = true;
            GlobalData.storageLocked = true;
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
