using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callDiagolue : MonoBehaviour
{
    float timer = 0;
    public GameObject TutorialCanvas;
    public GameObject UserCanvas;
    private static bool trigger = false;

    void Awake()
    {
        if (!trigger)
        {
            TutorialCanvas.SetActive(true);
            trigger = true;
        }
        else
        {
            UserCanvas.SetActive(true);
        }
    }

    //void Update()
    //{
    //    if (!trigger) {
    //        timer += Time.deltaTime;
    //        if (timer >= 1) {
    //            TutorialCanvas.SetActive(true);
    //            trigger = true;
    //            counter++;
    //        }
    //    }
    //    else
    //    {
    //        GameObject.Find("UserCanvas").SetActive(true);
    //    }
    //}
}
