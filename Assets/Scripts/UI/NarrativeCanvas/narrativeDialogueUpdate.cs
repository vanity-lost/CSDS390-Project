using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public GameObject NarrativeDialogue;
    public TextMeshProUGUI _narrativeDialogue;

    public AudioSource[] DialogueSounds;

    public string[] messages;

    public int currentMessageIndex;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        setMessageIndex(3);
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
        DialogueSounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if(currentMessageIndex >= 3 && currentMessageIndex <= 5)
        {
            timer += Time.deltaTime;
            if(timer > 0 && timer <= 5.1) {

                setMessageIndex(currentMessageIndex + 1);
            }
            else if (timer > 5.1 && timer <=9.1)
            {

            }
            else if(timer >=9.1 && timer <= 12.3) {

               
            }
            else
            {
                NarrativeDialogue.SetActive(false);
            }    
        } */
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
