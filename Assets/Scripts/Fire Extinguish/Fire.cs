using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject takeBoolText;
    public GameObject filler;
    public GameObject currentFire;
    public float holdTimeSet;
    public UnityEvent holdClick;

    private bool mouseHold;
    private float holdTimeSoFar;

    // Start is called before the first frame update
    void Start()
    {
        filler.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (filler.GetComponent<Image>().fillAmount >= 1)
        {
            currentFire.SetActive(false);
        }

        if (checkTakeStatus())//is holding an extinguisher
        {
            if (mouseHold == true)
            {
                holdTimeSoFar += Time.deltaTime;
                if (holdTimeSoFar >= holdTimeSet)
                {
                    if (holdClick != null)
                    {
                        holdClick.Invoke();
                    }
                    //inactive the filler image
                }
                filler.GetComponent<Image>().fillAmount = holdTimeSoFar / holdTimeSet;
            }
            else
            {
                if (holdTimeSoFar > 0)
                {
                    releaseHold();
                }

            }
        }
        else
        {
            //if holdertimesofar>0, then reduce filler amount
            if (holdTimeSoFar > 0)
            {
                releaseHold();
            }
        }
    }

    public bool checkTakeStatus()
    {
        if (takeBoolText.GetComponent<Text>().text == "False")
        {
            //Debug.Log("Extinguisher not taking");
            return false;
        }
        else if (takeBoolText.GetComponent<Text>().text == "True")
        {
            //Debug.Log("Extinguisher taking");
            return true;
        }
        return false;
    }

    public void releaseHold()
    {

        holdTimeSoFar -= Time.deltaTime / 10;
        //Debug.Log("is reducing filler amount");
        filler.GetComponent<Image>().fillAmount = holdTimeSoFar / holdTimeSet;
        //Debug.Log(filler.GetComponent<Image>().fillAmount);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseHold = true;
        //Debug.Log("OnPointerDown()");
        //if scale <= 0, then do nothing
        //else add filler amount
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseHold = false;
        //Debug.Log("OnPointerUp()");
        //if scale <= 0, then setactive = false
        //else reduce filler amount
    }
}
