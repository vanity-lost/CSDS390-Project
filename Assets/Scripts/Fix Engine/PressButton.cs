using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    bool buttonPressed;
    [SerializeField] private int numBolts = 3;

    int boltsDone = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Button is " + buttonPressed);
    }

    public void BoltDone()
    {
        boltsDone++;
    }

    private void OnMouseDown()
    {
        if (boltsDone == numBolts)
        {
            buttonPressed = true;
            GlobalData.engineBroken = false;
            ESCDectect.gameIsPaused = false;
            SceneManager.LoadScene("Main");
        }
    }
}
