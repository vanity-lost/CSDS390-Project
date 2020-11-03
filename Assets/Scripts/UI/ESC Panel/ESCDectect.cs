using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCDectect : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;

    public static bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (!dialogueUpdate.locked) {
            if (Input.GetKeyDown(KeyCode.Escape) && !Panel2.active && !Panel3.active && !Panel4.active) {
                Panel1.SetActive(!Panel1.activeSelf);
                if (gameIsPaused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }
    }

    public void Resume() 
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
