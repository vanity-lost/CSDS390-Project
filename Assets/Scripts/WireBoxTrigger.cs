﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;

public class WireBoxTrigger : MonoBehaviour
{
    public bool triggerStatus;
    public bool isTheBrokenOne;
    //public GameObject boxCover;

    [SerializeField] GameObject wirebox1;
    [SerializeField] GameObject wirebox2;
    [SerializeField] GameObject boxCover;
    [SerializeField] GameObject brokenEffect;

    // Start is called before the first frame update
    void Start()
    {
        triggerStatus = false;
        //isTheBrokenOne = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTheBrokenOne)
        {
            boxCover.SetActive(false);
            brokenEffect.SetActive(true);
        }
        else
        {
            boxCover.SetActive(true) ;
            brokenEffect.SetActive(false);
        }
    }

    public bool getBrokenStatus()
    {
        return isTheBrokenOne;
    }

    public void setBrokenStatus(bool newBrokenStatus)
    {
        if(!wirebox1.GetComponent<WireBoxTrigger>().getBrokenStatus() && !wirebox2.GetComponent<WireBoxTrigger>().getBrokenStatus())
        {
            this.isTheBrokenOne = newBrokenStatus;
        }
        else
        {
            Debug.Log("there is already a broken wirebox exists!");
        }
        
    }

    public bool getTriggerStatus()
    {
        return triggerStatus;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerStatus = true;
        //Debug.Log("Is triggering with wire box");
    }

    private void OnTriggerExit(Collider other)
    {

        triggerStatus = false; 
        //Debug.Log("Left wire box trigger area");
    }
}