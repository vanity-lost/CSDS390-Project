using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene("End Scene");
        }
    }
}
