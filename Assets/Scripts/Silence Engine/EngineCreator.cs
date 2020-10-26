using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EngineCreator : MonoBehaviour
{
    public GameObject Panel;
    //public RadarTimer Timer;
    public List<Slider> sliders = new List<Slider>();
    public bool[] answers = new bool[] {true, true, true, false, false};
    int numSliders = 5;
    public Slider slider1;
    public int numClicked; // can be randomly generated along w/ code
    public int numLeft;
    float totalTime = 15f;
    public GameObject TimerTextObject;
    Text timer;

    // Start is called before the first frame update
    void Start()
    {
        TimerTextObject = GameObject.Find("TimerText");
        timer = TimerTextObject.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        UpdateLevelTimer(totalTime );
        if (totalTime <= 0f)
            {
                StartCoroutine(EndTaskFail());
                //StartCoroutine(reload this scene); 
            }
        int count = 0;
        for (int i = 0; i < sliders.Count; i++) {
            if ((sliders[i].value == 1 && answers[i]) || (sliders[i].value == 0 && !answers[i])) {
                count++;
            }
        }
        if (count == numSliders) {
            StartCoroutine(EndTask());
        }
            
    }

    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Sliders");
        SceneManager.LoadScene("Main");
    }

     IEnumerator EndTaskFail()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Time ran out");
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
