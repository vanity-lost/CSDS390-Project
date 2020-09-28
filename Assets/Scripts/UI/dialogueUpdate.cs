using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueUpdate : MonoBehaviour
{
    public TextMeshProUGUI _dialogue;
    public GameObject tutorialCanvas;
    public GameObject UserCanvas;

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;

    public string[] messages;
    public int currentMessageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        ESCDectect.gameIsPaused = true;
        _dialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMessageIndex >= messages.Length - 1) {
            ESCDectect.gameIsPaused = false;
            tutorialCanvas.SetActive(false);
        }

        if (Input.anyKeyDown) {
            currentMessageIndex++;
            if (currentMessageIndex == 2) {
                UserCanvas.SetActive(true);
            } else if (currentMessageIndex == 3) {
                Arrow1.SetActive(true); 
            } else if (currentMessageIndex == 4) {
                Arrow1.SetActive(false); 
                Arrow2.SetActive(true); 
            } else if (currentMessageIndex == 5) {
                Arrow2.SetActive(false); 
                Arrow3.SetActive(true); 
            } else if (currentMessageIndex == 6) {
                Arrow3.SetActive(false); 
                Arrow4.SetActive(true); 
            } else if (currentMessageIndex > 6) {
                Arrow4.SetActive(false); 
            }
            _dialogue.SetText(messages[currentMessageIndex]);
        }

    }
}
