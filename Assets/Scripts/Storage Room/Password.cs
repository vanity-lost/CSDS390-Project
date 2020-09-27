using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Password : MonoBehaviour
{

    public GameObject Panel;
    public GameObject ProgressBar;
    public GameObject BarFiller;
    public string correctNum = "96318";//the correct password
    public char inputNum;//the inputing character
    public int numClicked;//the number of btn(s) being clicked so far
    public bool newinputdetected;

    // Start is called before the first frame update
    void Start()
    {
        numClicked = 0;
        //inputNum = '';
        newinputdetected = false;
        ProgressBar.GetComponent<Slider>().value = 0;
        BarFiller.GetComponent<Image>().color = new Color32(119, 255, 122, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (numClicked <= correctNum.Length)//during process of inputing
        {

            if (numClicked > 0)//start inputing
            {
                if (newinputdetected == true)
                {
                    //Debug.Log("correctPW[i]: " + correctNum[numClicked-1]);
                    //Debug.Log("inputPW: " + inputNum);
                    if (inputNum == correctNum[numClicked - 1])//if current input is correct
                    {

                        ProgressBar.GetComponent<Slider>().value++;//progress bar +1
                        Debug.Log("Correct Input +1");
                    }
                    else
                    {
                        //progress bar +1 and turn red
                        ProgressBar.GetComponent<Slider>().value++;//progress bar +1
                        BarFiller.GetComponent<Image>().color = new Color32(246, 59, 82, 255);
                        StartCoroutine(ReloadTask());
                        //StartCoroutine(reload this scene); 
                    }
                    newinputdetected = false;
                }

            }
        }
        if (numClicked == correctNum.Length && inputNum == correctNum[4])//room unlocked
        {

            StartCoroutine(EndTask());
        }
    }

    public void btnClickDetected(string btnNum)
    {
        numClicked++;
        inputNum = btnNum[0];
        newinputdetected = true;
        Debug.Log("button clicked:" + btnNum + "    numClicked:" + numClicked + "          inputNum:" + btnNum[0]);
    }


    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Password");
        SceneManager.LoadScene("Main");
    }

    IEnumerator ReloadTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Wrong Input!!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
