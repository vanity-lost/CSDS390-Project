using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    public void loadStart()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void loadMain()
    {
        ESCDectect.gameIsPaused = false;
        SceneManager.LoadScene("Main");
        GameObject.Find("Player").transform.position = new Vector3(0, 1.68f, 0);
        Screen.lockCursor = true;
        SubHealth.healthNum = 100;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game exited!");
    }
}
