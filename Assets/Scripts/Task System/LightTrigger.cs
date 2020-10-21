using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public bool lightTrigger = true;

    public GameObject EmergencyLight1;
    public GameObject EmergencyLight2;
    public GameObject EmergencyLight3;
    public GameObject EmergencyLight4;

    // Update is called once per frame
    void Update()
    {
        
        if (GlobalData.wiresBroken || GlobalData.fuseBroken) 
        {
            EmergencyLight1.SetActive(true);
            EmergencyLight2.SetActive(true);
            EmergencyLight3.SetActive(true);
            EmergencyLight4.SetActive(true);
        }
        if (!GlobalData.wiresBroken && !GlobalData.fuseBroken) 
        {
            EmergencyLight1.SetActive(false);
            EmergencyLight2.SetActive(false);
            EmergencyLight3.SetActive(false);
            EmergencyLight4.SetActive(false);
        }
    }
}
