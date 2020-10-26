using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class SubDistanceTracker : MonoBehaviour
{
    public Slider DistanceMeter;
    public bool engineRun = true;
    public static float traveledDistance = 0f;
    private float move = 1.0f;
    public static float maxDistance = 500.0f;
    private float elapsedTime = 0f;
    public static bool isMoving = true;

    void Start()
    {
        DistanceMeter.maxValue = maxDistance;
        DistanceMeter.value = traveledDistance;
    }
    
    void Update()
    {
        if (!ESCDectect.gameIsPaused && isMoving)
        //if (!ESCDectect.gameIsPaused)
        {
            DistanceTracker(DistanceMeter);
        }
    }

    private void DistanceTracker(Slider slider)
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
