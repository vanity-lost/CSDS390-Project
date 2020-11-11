using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public GameObject NarrativeDialogue;
    public TextMeshProUGUI _narrativeDialogue;

    public GameObject[] Lines;

    bool playing = false;

    public string[] messages;

    public int currentMessageIndex;

    float timer = 0;

    float[] timeStamps = {10,17,25};

    // Start is called before the first frame update
    void Start()
    {
        setMessageIndex(3);
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {

       if(NarrativeDialogue.activeSelf && currentMessageIndex >= 3 && currentMessageIndex <= 5)
        {
            if (!playing)
            {
                Lines[0].GetComponent<AudioSource>().Play();
                playing = true;
            }
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
                setMessageIndex(6);
                playing = false;
                NarrativeDialogue.SetActive(false);
            }
            
        }
        if (NarrativeDialogue.activeSelf && currentMessageIndex >= 6 && currentMessageIndex <= 8)
        {
            if (!playing)
            {
                Lines[1].GetComponent<AudioSource>().Play();
                playing = true;
            }
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
                setMessageIndex(9);
                playing = false;
                NarrativeDialogue.SetActive(false);
            }

        }

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
