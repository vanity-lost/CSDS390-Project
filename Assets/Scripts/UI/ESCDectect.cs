using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCDectect : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    public static bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Panel1.SetActive(!Panel1.activeSelf);
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
            Panel2.SetActive(false);
            Panel3.SetActive(false);
        }
    }

    void Resume() 
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
