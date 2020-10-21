using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Password : MonoBehaviour
{

    public GameObject Panel;
    public GameObject ProgressBar;
    public GameObject BarFiller;
    public string correctPIN = "eurydice";//the correct password
    public char inputChar;//the inputing character
    public int numClicked;//the number of btns being clicked so far
    public bool newinputdetected;

    // Start is called before the first frame update
    void Start()
    {
        numClicked = 0;
        newinputdetected = false;
        ProgressBar.GetComponent<Slider>().value = 0;
        BarFiller.GetComponent<Image>().color = new Color32(119, 255, 122, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }

        if (numClicked <= correctPIN.Length)//during process of inputing
        {

            if (numClicked > 0)//start inputing
            {
                if (newinputdetected == true)
                {
                    //Debug.Log("correctPW[i]: " + correctNum[numClicked-1]);
                    //Debug.Log("inputPW: " + inputNum);
                    if (inputChar == correctPIN[numClicked - 1])//if current input is correct
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
        if (numClicked == correctPIN.Length && inputChar == correctPIN[7])//room unlocked
        {

            StartCoroutine(EndTask());
        }
    }

    public void btnClickDetected(string btnNum)
    {
        numClicked++;
        inputChar = btnNum[0];
        newinputdetected = true;
        Debug.Log("button clicked:" + btnNum + "    numClicked:" + numClicked + "          inputChar:" + btnNum[0]);
    }


    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Correct Password");
        GlobalData.storageLocked = false;

        SceneManager.LoadScene("Main");
    }

    IEnumerator ReloadTask()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Wrong Input!!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
