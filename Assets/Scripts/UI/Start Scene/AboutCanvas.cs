using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutCanvas : MonoBehaviour
{
    public GameObject infoCanvas;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infoCanvas.SetActive(false);
        }
    }
}
