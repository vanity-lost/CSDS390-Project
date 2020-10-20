using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressToConti : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            PlayMinigame.engineTrigger = true;
            this.gameObject.SetActive(false);
        }
    }
}
