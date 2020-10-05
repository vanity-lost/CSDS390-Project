using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreenSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toFullscreen() 
    {
        Screen.fullScreen = true;
        Debug.Log("fullscreen");
    }

    public void toWindowed() 
    {
        Screen.fullScreen = false;
        Debug.Log("windowed");
    }
}
