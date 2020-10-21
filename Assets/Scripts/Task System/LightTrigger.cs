using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public bool lightTrigger = false;
    float timer = 0;

    public GameObject EmergencyLight1;
    public GameObject EmergencyLight2;
    public GameObject EmergencyLight3;
    public GameObject EmergencyLight4;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30 && !lightTrigger) 
        {
            lightTrigger = true;
            timer = 0;
        }
        if (lightTrigger) 
        {
            EmergencyLight1.SetActive(true);
            EmergencyLight2.SetActive(true);
            EmergencyLight3.SetActive(true);
            EmergencyLight4.SetActive(true);
        }
        if (!lightTrigger) 
        {
            EmergencyLight1.SetActive(false);
            EmergencyLight2.SetActive(false);
            EmergencyLight3.SetActive(false);
            EmergencyLight4.SetActive(false);
        }
    }
}
