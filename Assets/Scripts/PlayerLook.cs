using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float ySensitivity = 8.0f;
    float xSensitivity = 8.0f;
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
