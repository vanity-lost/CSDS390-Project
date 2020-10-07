using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WireBoxTrigger : MonoBehaviour
{
    public bool status;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getStatus()
    {
        return status;
    }

    private void OnTriggerEnter(Collider other)
    {
        status = true;
        //Debug.Log("Is triggering with wire box");
    }

    private void OnTriggerExit(Collider other)
    {

        status = false; 
        //Debug.Log("Left wire box trigger area");
    }
}
