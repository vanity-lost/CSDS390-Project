using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadarFix : MonoBehaviour // TODO timer needs some work
{
    Dictionary<Button, string> buttons;
    public Button buttonB;
    public Button buttonY;
    public Button buttonR;
    public GameObject Panel;
    //public RadarTimer Timer;
    public string correctCode = "afge";
    public string charClicked;
    public bool newInputDetected;
    public int numClicked; // can be randomly generated along w/ code
    public int numLeft;
    // Start is called before the first frame update
    void Start()
    {
    
        buttonB.onClick.AddListener(TaskOnClick);
        buttonY.onClick.AddListener(TaskOnClick);
        buttonR.onClick.AddListener(TaskOnClick);
        


        numLeft = 3;
        newInputDetected = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (numLeft == 0) 
        {
            StartCoroutine(EndTask());
        }

        if (numClicked <= correctCode.Length) 
        {
            if (newInputDetected == true) 
            {
                if(correctCode.Contains(charClicked)) 
                {
                    //TODO make input button disappear
                    Debug.Log("Correct character clicked");
                    numLeft--;
                }
                else 
                {
                    StartCoroutine(ReloadTask());
                    //StartCoroutine(reload this scene); 
                }
                newInputDetected = false;
            }
        }
        if (numLeft == 0)//radar on or off
        {

            StartCoroutine(EndTask());
        }
    }

    

    public void TaskOnClick()
    {
        numLeft--;
    }

    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Characters");
        SceneManager.LoadScene("Main");
    }

    IEnumerator ReloadTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Time Ran Out!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
