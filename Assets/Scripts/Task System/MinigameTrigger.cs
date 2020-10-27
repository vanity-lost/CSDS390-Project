using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public bool triggerStatus;
    public GameObject displayName;

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
    }

    private void OnTriggerExit(Collider other)
    {

        triggerStatus = false;
        displayName.SetActive(false);
    }
}
