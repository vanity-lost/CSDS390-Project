using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void exit() {
        Application.Quit();
        Debug.Log("Game exited!");
    }
}
