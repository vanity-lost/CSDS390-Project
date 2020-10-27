using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float ySensitivity;
    float xSensitivity;
    public float highY = 45.0f;
    public float lowY = -45.0f;

    float rotationY = 0f;

    public enum Rotation {
        x = 1,
        y = 2,
    }

public Rotation rotation = Rotation.x;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ESCDectect.gameIsPaused)
            Screen.lockCursor = false;
         else
            Screen.lockCursor = true; */
        /*if (ESCDectect.gameIsPaused) {
            xSensitivity = 0.0f;
            ySensitivity = 0.0f;
            lowY = 0.0f;
            highY = 0.0f;
        } else {*/
            xSensitivity = 4.0f;
            ySensitivity = 4.0f;
            lowY = -45.0f;
            highY = 45.0f;
        //}
        
        if (rotation == Rotation.x)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * xSensitivity, 0);

        }
        else
        {   
            rotationY -= Input.GetAxis("Mouse Y") * ySensitivity;
            rotationY = Mathf.Clamp(rotationY, lowY, highY);
            transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y, 0);
        }
        
    }
}
