using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// taken from a tutorial https://www.youtube.com/watch?v=S3pjBQObC90
// modified to fit the context of the project
public class PlayerIcon : MonoBehaviour
{
    public float speed=5f;
    public void Update(){
        float rotx = Input.GetAxis("Mouse X")*speed*Mathf.Deg2Rad;
        float roty = Input.GetAxis("Mouse Y")*speed*Mathf.Deg2Rad;

        transform.RotateAround(new Vector3(0f,0f,1f), -rotx);
    }
}
