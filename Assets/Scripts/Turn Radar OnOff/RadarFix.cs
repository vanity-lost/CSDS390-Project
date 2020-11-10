using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadarFix : MonoBehaviour // TODO timer needs some work
{
    public List<Button> buttons = new List<Button>();
    public GameObject Panel;
    //public RadarTimer Timer;
    public int target;
    public string charClicked;
    public bool newInputDetected;
    public char inputChar;
    public int numClicked; // can be randomly generated along w/ code
    public int numLeft = 0;
    float totalTime = 10f;
    public GameObject TimerTextObject;
    Text timer;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in buttons)
        {
            Text displayText = button.GetComponentInChildren(typeof(Text)) as Text;
            displayText.gameObject.SetActive(false);
            int rand = RandomSign();
            if (rand == 1 ) {
               displayText.gameObject.SetActive(true);
               numLeft++;
            }

        }
        TimerTextObject = GameObject.Find("TimerText");
        timer = TimerTextObject.GetComponent<Text>();


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
        }
                
        if (numLeft == 0) 
        {
            StartCoroutine(EndTask());
        }

        //if (numClicked <= correctCode.Length) 
        //{
           // if (newInputDetected == true) 
           // {
           //     if(correctCode.Contains(charClicked)) 
            //    {
                    //TODO make input button disappear
              //      Debug.Log("Correct character clicked");
               //     numLeft--;
              //  }
              //  else
              //  {
              //       StartCoroutine(ReloadTask());
              //  }
              //  newInputDetected = false;
           // }
       // }
       // if (numLeft == 0)//radar on or off
        //{

        //    StartCoroutine(EndTask());
       // }
    }

    public void btnClickDetected(Button clickedButton)
    {
        Text displayText = clickedButton.GetComponentInChildren(typeof(Text)) as Text;
        if (displayText.gameObject.activeSelf) 
        {
            displayText.gameObject.SetActive(false);
            numLeft--;
        }

        //inputChar = btnNum[0];
        newInputDetected = true;
        //Debug.Log("button clicked:" + btnNum + "    numClicked:" + numClicked + "          inputChar:" + btnNum[0]);
    }

    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Characters");
        GlobalData.radarOn = !GlobalData.radarOn;
        SceneManager.LoadScene("Main");
        ESCDectect.gameIsPaused = false;
        
    }

     IEnumerator EndTaskFail()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Characters");
        ESCDectect.gameIsPaused = false;
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

    public static int RandomSign()
    {
         return UnityEngine.Random.value < 0.5f ? 1 : -1;
    }
}