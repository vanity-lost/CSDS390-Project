using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMainScene : MonoBehaviour
{
    public void loadlevel()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
