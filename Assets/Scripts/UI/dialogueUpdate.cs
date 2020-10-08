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

    public GameObject ImageW;
    public GameObject ImageA;
    public GameObject ImageS;
    public GameObject ImageD;

    public GameObject ImageE;
    public GameObject ImageRightClick;

    public GameObject ImageEsc;
    public GameObject ImageTab;

    bool checkAll = true;

    public string[] messages;
    public int currentMessageIndex = 0;

    public static bool locked = true;

    float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        ESCDectect.gameIsPaused = true;
        locked = true;
        _dialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMessageIndex >= messages.Length - 1) {
            ESCDectect.gameIsPaused = false;
            locked = false;
            tutorialCanvas.SetActive(false);
        }

        if (currentMessageIndex == 2) {
            timer += Time.deltaTime;
            if (timer >= 0.5 && timer < 1)
                UserCanvas.SetActive(false);
            if (timer >= 1 && timer < 1.5)
                UserCanvas.SetActive(true);
            if (timer >= 1.5 && timer < 2)
                UserCanvas.SetActive(false);
            if (timer >= 2) {
                UserCanvas.SetActive(true);
                checkAll = true;
            }
        }    

        if (currentMessageIndex == 8 && ImageW.active && Input.GetKeyDown(KeyCode.W)) {
            ImageW.SetActive(false);
        }    
        
        if (currentMessageIndex == 8 && ImageA.active && Input.GetKeyDown(KeyCode.A)) {
            ImageA.SetActive(false);
        } 
        
        if (currentMessageIndex == 8 && ImageS.active && Input.GetKeyDown(KeyCode.S)) {
            ImageS.SetActive(false);
        } 
        
        if (currentMessageIndex == 8 && ImageD.active && Input.GetKeyDown(KeyCode.D)) {
            ImageD.SetActive(false);
        } 

        if (currentMessageIndex == 8 && !ImageD.active && !ImageA.active && !ImageS.active && !ImageD.active) {
            checkAll = true;
        }

        if (currentMessageIndex == 9 && ImageE.active && Input.GetKeyDown(KeyCode.E)) {
            ImageE.SetActive(false);
        }    
        
        if (currentMessageIndex == 9 && ImageRightClick.active && Input.GetKeyDown(KeyCode.Mouse1)) {
            ImageRightClick.SetActive(false);
        } 

        if (currentMessageIndex == 9 && !ImageE.active && !ImageRightClick.active) {
            checkAll = true;
        }

        if (currentMessageIndex == 10 && ImageEsc.active && Input.GetKeyDown(KeyCode.Escape)) {
            ImageEsc.SetActive(false);
        } 

        if (currentMessageIndex == 10 && ImageTab.active && Input.GetKeyDown(KeyCode.Tab)) {
            ImageTab.SetActive(false);
        }

        if (currentMessageIndex == 10 && !ImageEsc.active && !ImageTab.active) {
            checkAll = true;
        }

        if (checkAll && Input.anyKeyDown) {
            currentMessageIndex++;
            if (currentMessageIndex == 2) {
                checkAll = false;
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
            } else if (currentMessageIndex == 7) {
                Arrow4.SetActive(false); 
            } else if (currentMessageIndex == 8) {
                checkAll = false;
                ImageW.SetActive(true);
                ImageA.SetActive(true);
                ImageS.SetActive(true);
                ImageD.SetActive(true);
            } else if (currentMessageIndex == 9) {
                checkAll = false;
                ImageE.SetActive(true);
                ImageRightClick.SetActive(true);
            } else if (currentMessageIndex == 10) {
                checkAll = false;
                ImageEsc.SetActive(true);
                ImageTab.SetActive(true);
            } 
            _dialogue.SetText(messages[currentMessageIndex]);
        }

    }
}
