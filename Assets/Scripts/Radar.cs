using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private Transform sweeperTransform;
    private float rotSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        sweeperTransform = transform.Find("RadarLine");
        rotSpeed  = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        sweeperTransform.eulerAngles += new Vector3(0,0,-rotSpeed * Time.deltaTime);
    }
}
