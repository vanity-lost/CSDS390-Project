using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{
    public GameObject scrollView;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5) {
            time = 0;
            scrollView.SetActive(!scrollView.activeSelf);
        }
    }
}
