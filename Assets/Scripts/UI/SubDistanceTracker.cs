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
    private float move = 5.0f;
    public static float maxDistance = 500.0f;
    private float elapsedTime = 0f;
    public static bool isMoving = true;
    public static bool checkPoint1 = false;
    public static bool checkPoint2 = false;
    public static float checkPoint1Distance;
    public static float checkPoint2Distance;
    public int NUM_CHECK_POINTS = 3;

    public GameObject NarrativeDialogue;

    void Start()
    {
        DistanceMeter.maxValue = maxDistance;
        DistanceMeter.value = traveledDistance;
        checkPoint1Distance = maxDistance/NUM_CHECK_POINTS;
        checkPoint2Distance = 2*(maxDistance/NUM_CHECK_POINTS);
    }
    
    void Update()
    {
        if (!dialogueUpdate.locked && isMoving)
        //if (!ESCDectect.gameIsPaused)
        {
            DistanceTracker(DistanceMeter);
        }

        if(traveledDistance >= checkPoint1Distance && !checkPoint1) {
            checkPoint1 = true;
            NarrativeDialogue.SetActive(true);
        }

        if(traveledDistance >= checkPoint2Distance && !checkPoint2) {
            checkPoint2 = true;
            NarrativeDialogue.SetActive(true);
        }
    }

    private void DistanceTracker(Slider slider)
    {
        elapsedTime += Time.deltaTime;
        if  (engineRun == true && elapsedTime >= 1.0f)
        {
            elapsedTime = elapsedTime % 1.0f;
            traveledDistance += move;
            Debug.Log(traveledDistance);
            slider.value = traveledDistance;
            if (traveledDistance == maxDistance)
            {
                engineRun = false;
            }
        }
    }
}
