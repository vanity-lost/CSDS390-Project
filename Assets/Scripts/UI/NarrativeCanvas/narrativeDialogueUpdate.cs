using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public GameObject NarrativeDialogue;
    public TextMeshProUGUI _narrativeDialogue;

    public GameObject[] DialogueSounds;

    public string[] messages;

    public int currentMessageIndex;

    float timer = 0;

    float[] timeStamps = {10,17,25};

    // Start is called before the first frame update
    void Start()
    {
        setMessageIndex(3);
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
        DialogueSounds = GetComponents<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

       if(NarrativeDialogue.activeSelf && currentMessageIndex >= 3 && currentMessageIndex <= 5)
        {
            DialogueSounds[0].SetActive(true);
            timer += Time.deltaTime;   
            if(timer > 0 && timer < 0.5)
            {
                setMessageIndex(3);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            if (timer >= timeStamps[0] && timer <= timeStamps[0]+0.1) {
                setMessageIndex(4);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            else if (timer >= timeStamps[1] && timer <= timeStamps[1] + 0.1)
            {
                setMessageIndex(5);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            else if(timer >= timeStamps[2]) {
                timer = 0;
                DialogueSounds[0].SetActive(false);
                setMessageIndex(6);
                NarrativeDialogue.SetActive(false);
            }
            
        }
        if (NarrativeDialogue.activeSelf && currentMessageIndex >= 6 && currentMessageIndex <= 8)
        {
            DialogueSounds[1].SetActive(true);
            timer += Time.deltaTime;
            if (timer > 0 && timer < 0.5)
            {
                setMessageIndex(6);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            if (timer >= timeStamps[0] && timer <= timeStamps[0] + 0.1)
            {
                setMessageIndex(7);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            else if (timer >= timeStamps[1] && timer <= timeStamps[1] + 0.1)
            {
                setMessageIndex(8);
                _narrativeDialogue.SetText(messages[currentMessageIndex]);
            }
            else if (timer >= timeStamps[2])
            {
                timer = 0;
                DialogueSounds[1].SetActive(false);
                setMessageIndex(9);
                NarrativeDialogue.SetActive(false);
            }

        }

        /* if (currentMessageIndex > 5 && SubDistanceTracker.traveledDistance < SubDistanceTracker.checkPoint2Distance)
         {
             NarrativeDialogue.SetActive(false);
         }
         else if (currentMessageIndex > 8 && (SubDistanceTracker.traveledDistance < SubDistanceTracker.maxDistance))
         {
             NarrativeDialogue.SetActive(false);
         }
         else
         {

         }*/


        /* if (Input.anyKeyDown)
         {
             //make a timer for the sounds
             setMessageIndex(currentMessageIndex + 1);
         }*/

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
