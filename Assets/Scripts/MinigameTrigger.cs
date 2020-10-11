using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public bool triggerStatus;

    void Start()
    {
        triggerStatus = false;
    }


    public bool getTriggerStatus()
    {
        return triggerStatus;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerStatus = true;
    }

    private void OnTriggerExit(Collider other)
    {

        triggerStatus = false;
    }
}
