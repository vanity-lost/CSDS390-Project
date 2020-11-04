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
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game exited!");
    }
}
