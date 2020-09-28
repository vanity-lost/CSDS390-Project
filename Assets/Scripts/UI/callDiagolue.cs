using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callDiagolue : MonoBehaviour
{
    float timer = 0;
    public GameObject TutorialCanvas;
    private bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!trigger) {
            timer += Time.deltaTime;
            if (timer >= 1) {
                TutorialCanvas.SetActive(true);
                trigger = true;
            }
        }
    }
}
