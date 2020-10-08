using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeriscopeBackBtn : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("Loading Main Scene");
    }
}