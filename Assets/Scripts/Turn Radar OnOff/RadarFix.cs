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
    float totalTime = 15f;
    public GameObject TimerTextObject;
    Text timer;
    // Start is called before the first frame update
    void Start()
    {
    
        buttonB.onClick.AddListener(TaskOnClick);
        buttonY.onClick.AddListener(TaskOnClick);
        buttonR.onClick.AddListener(TaskOnClick);
        TimerTextObject = GameObject.Find("TimerText");
        timer = TimerTextObject.GetComponent<Text>();


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

        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime );

        if (totalTime <= 0f)
            {
                StartCoroutine(EndTaskFail());
                //StartCoroutine(reload this scene); 
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

     IEnumerator EndTaskFail()
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

    public void UpdateLevelTimer(float totalSeconds)
    {
             int minutes = Mathf.FloorToInt(totalSeconds / 60f);
             int seconds = Mathf.RoundToInt(totalSeconds % 60f);
 
             string formatedSeconds = seconds.ToString();
 
             if (seconds == 60)
             {
                 seconds = 0;
                 minutes += 1;
             }
 
             timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
