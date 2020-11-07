using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public TextMeshProUGUI _narrativeDialogue;
    public TextMeshProUGUI _continueHints;

    public string[] messages;

    public int currentMessageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        //this will probably just need its own methods, rather than using Update
        if (SubDistanceTracker.checkPoint1 && !SubDistanceTracker.checkPoint2)
        {
            currentMessageIndex = 3;
            
        }
        else if (SubDistanceTracker.checkPoint2)
        {
            //play the second set
            currentMessageIndex = 6;

        }
        else
        {
            //if at the end play the final lines
            currentMessageIndex = 9;
        }
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
        
    }
}
