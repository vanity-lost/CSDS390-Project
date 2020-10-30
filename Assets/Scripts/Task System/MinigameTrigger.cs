using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public bool triggerStatus;
    public GameObject displayName;
    //public GameObject displayLocNameList;

    void Start()
    {
        triggerStatus = false;
        displayName.SetActive(false);
    }


    public bool getTriggerStatus()
    {
        return triggerStatus;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerStatus = true;
        displayName.SetActive(true);
        //displayName.SetActive(true);
        //Debug.Log(displayName.activeSelf);
    }

    private void OnTriggerExit(Collider other)
    {

        triggerStatus = false;
        displayName.SetActive(false);
    }
}
