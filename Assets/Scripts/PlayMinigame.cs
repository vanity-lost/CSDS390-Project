using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMinigame : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueUpdate.locked) {
            if (Input.GetKeyDown("q") & (Vector3.Distance(transform.position, engine.transform.position) < distance) & GlobalData.engineBroken)
            {
                SceneManager.LoadScene("Fix Engine");
            }
            if (Input.GetKeyDown("l") & GlobalData.wiresBroken)
            {
                SceneManager.LoadScene("Connect Wire");
            }
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
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene("End Scene");
            }
        }
        if (Time.time > 30 &  GlobalData.updateEngine == false) 
        {
            Debug.Log("Broke Engine");
            GlobalData.updateEngine = true;
            GlobalData.engineBroken = true;
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
