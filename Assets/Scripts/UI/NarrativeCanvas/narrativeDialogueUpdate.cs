using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public GameObject NarrativeDialogue;
    public TextMeshProUGUI _narrativeDialogue;

    public string[] messages;

    public int currentMessageIndex;

    // Start is called before the first frame update
    void Start()
    {
        setMessageIndex(3);
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        //this will probably just need its own methods, rather than using Update
        if (currentMessageIndex > 5 && SubDistanceTracker.traveledDistance < SubDistanceTracker.checkPoint2Distance)
        {
            NarrativeDialogue.SetActive(false);
        }
        else if (currentMessageIndex > 8 && (SubDistanceTracker.traveledDistance < SubDistanceTracker.maxDistance))
        {
            NarrativeDialogue.SetActive(false);
        }
        else
        {
            
        }

        if (Input.anyKeyDown)
        {
            //make a timer for the sounds
            setMessageIndex(currentMessageIndex + 1);
        }
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
        
    }

    public int getMessageIndex()
    {
        return currentMessageIndex;
    }

    public void setMessageIndex(int i)
    {
        currentMessageIndex = i;
    }
}
