using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QTESys : MonoBehaviour
{
    public GameObject LetterBox;//display the key player needs to press
    public GameObject LetterBoxOuter;
    public GameObject PassBox;//display if pass or fail the current QTE
    public GameObject NumSuccess;//display number of successed QTE
    public GameObject Panel;
    public GameObject Bar;
    public GameObject CheckFiller;
    public GameObject BoxCover;
    public Sprite EKey;
    public Sprite RKey;
    public Sprite TKey;
    public Sprite EmptyKey;
    public int QTEGen;//so far 3 different types of QTE letter, E R T, 4=wrong key pressed
    public int WaitingForKey;//0=is waiting to generate a QTE key
    public int CorrectKey;//1=correct key pressed,2=wrong key pressed,0=reset this state
    public int CountingDown;
    public int numofcorrect;
    public float TimeLeft;
    public int maxprogress = 5;

    void Start()
    {
        NumSuccess.GetComponent<Text>().text = "0";
        numofcorrect = Int32.Parse(NumSuccess.GetComponent<Text>().text);
        Debug.Log(NumSuccess.GetComponent<Text>().text);
        Bar.GetComponent<Slider>().value = 0;
        CheckFiller.GetComponent<Image>().color = new Color32(210, 20, 0, 0);//transparent
        LetterBoxOuter.GetComponent<Image>().sprite = EmptyKey;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCDectect.gameIsPaused = false;
            SceneManager.LoadScene("Main");
        }

        numofcorrect = Int32.Parse(NumSuccess.GetComponent<Text>().text);
        if (numofcorrect < 4 && Panel.activeSelf == true)
        {
            if (WaitingForKey == 0)
            {
                QTEGen = UnityEngine.Random.Range(1, 4);
                CountingDown = 1;
                StartCoroutine(CountDown());
                if (QTEGen == 1)
                {
                    WaitingForKey = 1;
                    LetterBoxOuter.GetComponent<Image>().sprite = EKey;
                    LetterBox.GetComponent<Text>().text = "[E]";
                }
                if (QTEGen == 2)
                {
                    WaitingForKey = 1;
                    LetterBoxOuter.GetComponent<Image>().sprite = RKey;
                    LetterBox.GetComponent<Text>().text = "[R]";
                }
                if (QTEGen == 3)
                {
                    WaitingForKey = 1;
                    LetterBoxOuter.GetComponent<Image>().sprite = TKey;
                    LetterBox.GetComponent<Text>().text = "[T]";
                }
            }

            if (QTEGen == 1)
            {
                if (Input.anyKeyDown)
                {
                    if(Input.GetKeyDown("e"))//if (Input.GetButtonDown("EKey"))
                    {
                        CorrectKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else//if not pressing the right key
                    {
                        CorrectKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }
            if (QTEGen == 2)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown("r"))
                    {
                        CorrectKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else//if not pressing the right key
                    {
                        CorrectKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }
            if (QTEGen == 3)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown("t"))
                    {
                        CorrectKey = 1;
                        StartCoroutine(KeyPressing());
                    }
                    else//if not pressing the right key
                    {
                        CorrectKey = 2;
                        StartCoroutine(KeyPressing());
                    }
                }
            }
        }
        else if (PassBox.GetComponent<Text>().text == "Connected!")
        {
            //do nothing, just wait;
        }
        else if (numofcorrect >= 3 && Panel.activeSelf == true)
        {
            PassBox.GetComponent<Text>().text = "Connected!";
            CheckFiller.GetComponent<Image>().color = new Color32(20, 210, 0, 255);//turn green
            Debug.Log("Connected");
            StartCoroutine(EndWireConnection());
        }
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 4;
        if (CorrectKey == 1)//done it correctly
        {
            numofcorrect = numofcorrect + 1;
            Bar.GetComponent<Slider>().value = numofcorrect;
            NumSuccess.GetComponent<Text>().text = "" + numofcorrect + "";
            CountingDown = 2;
            //PassBox.GetComponent<Text>().text = "PASS!";
            Debug.Log("PASS");
            LetterBoxOuter.GetComponent<Image>().color = new Color32(215, 215, 215, 255);//pressed effect
            //BoxCover.GetComponent<Animator>().Play("BoxCoverSliding");
            LetterBoxOuter.GetComponent<Animator>().Play("ButtonShifting");
            LetterBoxOuter.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBoxOuter.GetComponent<Image>().sprite = EmptyKey;
            LetterBox.GetComponent<Text>().text = "";
            LetterBoxOuter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);//release effect
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 2)//incorrect key pressed
        {
            CountingDown = 2;
            //PassBox.GetComponent<Text>().text = "FAIL!";
            Debug.Log("FAIL");
            CheckFiller.GetComponent<Image>().color = new Color32(210, 20, 0, 255);
            yield return new WaitForSeconds(1f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBoxOuter.GetComponent<Image>().sprite = EmptyKey;
            LetterBox.GetComponent<Text>().text = "";
            CheckFiller.GetComponent<Image>().color = new Color32(210, 20, 0, 0);
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {//wait and refresh everything
        yield return new WaitForSeconds(0.5f);
        if (CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            //PassBox.GetComponent<Text>().text = "FAIL!";
            CheckFiller.GetComponent<Image>().color = new Color32(210, 20, 0, 255);
            yield return new WaitForSeconds(1f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBoxOuter.GetComponent<Image>().sprite = EmptyKey;
            LetterBox.GetComponent<Text>().text = "";
            CheckFiller.GetComponent<Image>().color = new Color32(210, 20, 0, 0);
            yield return new WaitForSeconds(0.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator EndWireConnection()
    {
        yield return new WaitForSeconds(0.5f);
        Panel.SetActive(false);
        Debug.Log("animation played");
        BoxCover.GetComponent<Animator>().Play("BoxCoverSliding");
        yield return new WaitForSeconds(1f);
        Debug.Log("Main");
        GlobalData.wiresBroken = false;
        //GlobalData.updateWires = false;
        ESCDectect.gameIsPaused = false;
        SceneManager.LoadScene("Main");
    }

}
