using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class SubDistanceTracker : MonoBehaviour
{
    public Slider DistanceMeter;
    public bool engineRun = true;
    private static float traveledDistance = 0f;
    private float move = 1.0f;
    private float maxDistance = 500.0f;
    private float elapsedTime = 0f;

    void Start()
    {
        DistanceMeter.maxValue = maxDistance;
        DistanceMeter.value = traveledDistance;
    }
    
    void Update()
    {
        if (!ESCDectect.gameIsPaused && GlobalData.engineBroken == false)
        //if (!ESCDectect.gameIsPaused)
        {
            DistanceTracker(DistanceMeter);
        }
    }

    private void DistanceTracker (Slider slider)
    {
        elapsedTime += Time.deltaTime;
        if  (engineRun == true && elapsedTime >= 1.0f)
        {
            elapsedTime = elapsedTime % 1.0f;
            traveledDistance += move;
            slider.value = traveledDistance;
            if (traveledDistance == maxDistance)
            {
                engineRun = false;
            }
        }
    }
}
