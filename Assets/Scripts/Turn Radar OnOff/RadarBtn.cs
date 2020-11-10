using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarBtn : MonoBehaviour
{
    public GameObject offBtn;
    public GameObject onBtn;

    public static bool radarOn = true;

    public void Power()
    {
        if (radarOn)
        {
            // radar is off
            radarOn = false;
            offBtn.SetActive(true);
            onBtn.SetActive(false);
            Radar.sweeperOn = false;
        }
        else
        {
            // radar is on
            radarOn = true;
            onBtn.SetActive(true);
            offBtn.SetActive(false);
            Radar.sweeperOn = true;
        }
    }
}
