using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    public GameObject LetterBox;//display the key player needs to press
    public GameObject PassBox;//display if pass or fail the current QTE
    public GameObject NumSuccess;//display number of successed QTE
    public GameObject FilledBar;
    public GameObject Panel;
    public GameObject closebutton;
    public int QTEGen;//so far 3 different types of QTE letter, E R T, 4=wrong key pressed
    public int WaitingForKey;//0=is waiting to generate a QTE key
    public int CorrectKey;//1=correct key pressed,2=wrong key pressed,0=reset this state
    public int CountingDown;
    public int numofcorrect;
    public float TimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        NumSuccess.GetComponent<Text>().text = "0";
        numofcorrect = Int32.Parse(NumSuccess.GetComponent<Text>().text);
        Debug.Log(NumSuccess.GetComponent<Text>().text);
        TimeLeft = FilledBar.GetComponent<Image>().fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        numofcorrect = Int32.Parse(NumSuccess.GetComponent<Text>().text);
        if (numofcorrect < 3 && Panel.activeSelf == true)
        {
            if (WaitingForKey == 0)
            {
                QTEGen = UnityEngine.Random.Range(1, 4);
                CountingDown = 1;
                StartCoroutine(CountDown());
                //StartCoroutine(TimerCountDown());
                if (QTEGen == 1)
                {
                    WaitingForKey = 1;
                    LetterBox.GetComponent<Text>().text = "[E]";
                }
                if (QTEGen == 2)
                {
                    WaitingForKey = 1;
                    LetterBox.GetComponent<Text>().text = "[R]";
                }
                if (QTEGen == 3)
                {
                    WaitingForKey = 1;
                    LetterBox.GetComponent<Text>().text = "[T]";
                }
            }

            if (QTEGen == 1)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetButtonDown("EKey"))
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
                    if (Input.GetButtonDown("RKey"))
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
                    if (Input.GetButtonDown("TKey"))
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
        /**else if(numofcorrect != Int32.Parse(NumSuccess.GetComponent<Text>().text))
        {
            numofcorrect = Int32.Parse(NumSuccess.GetComponent<Text>().text);
            PassBox.GetComponent<Text>().text = "";
        }**/
        else if (numofcorrect >= 3 && Panel.activeSelf == true)
        {
            //Debug.Log(numofcorrect);
            //Debug.Log(Panel.activeSelf.ToString());
            PassBox.GetComponent<Text>().text = "Connected!";
            StartCoroutine(EndWireConnection());
        }

    }


    IEnumerator KeyPressing()
    {
        QTEGen = 4;
        if (CorrectKey == 1)//done it correctly
        {
            numofcorrect = numofcorrect + 1;
            NumSuccess.GetComponent<Text>().text = "" + numofcorrect + "";

            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 2)//incorrect key pressed
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {//wait and refresh everything
        yield return new WaitForSeconds(3.5f);
        if (CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            LetterBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator EndWireConnection()
    {
        yield return new WaitForSecondsRealtime(2);
        closebutton.GetComponent<Button>().onClick.Invoke();
    }

    IEnumerator TimerCountDown()
    {
        yield return new WaitForSeconds(3.5f);
        while (TimeLeft != 0)
        {
            TimeLeft = TimeLeft - (1 / 3.5f);
            FilledBar.GetComponent<Image>().fillAmount = TimeLeft;
        }

    }

}


