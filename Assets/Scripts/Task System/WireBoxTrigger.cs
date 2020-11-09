using System.Collections;
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
    [SerializeField] GameObject displayName;

    // Start is called before the first frame update
    void Start()
    {
        triggerStatus = false;
        isTheBrokenOne = false;
        if (brokenEffect != null)
        {
            brokenEffect.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTheBrokenOne)
        {
            //Debug.Log("wire broke");
            boxCover.SetActive(false);
            if (brokenEffect != null){
                //Debug.Log("wire broke with sparks effect on");
                brokenEffect.SetActive(true);
            }
            
        }
        else
        {
            boxCover.SetActive(true) ;
            if (brokenEffect != null)
            {
                brokenEffect.SetActive(false);
            }
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
        displayName.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {

        triggerStatus = false;
        displayName.SetActive(false);
    }
}
