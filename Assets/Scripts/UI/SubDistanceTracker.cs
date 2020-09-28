using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class SubDistanceTracker : MonoBehaviour
{
    public Slider DistanceMeter;
    public bool engineRun = true;
    private float tDistance = 0f;
    private float move = 0.1f;
    private float maxDistance = 1.0f;


    // Update is called once per frame
    void Update()
    {
        while(engineRun)
        {
            // yield return new WaitForSeconds(1);
            tDistance += move;
            DistanceMeter.value = tDistance;

            if(tDistance == maxDistance)
            {
                engineRun = false;
            }
        }
    }
}
