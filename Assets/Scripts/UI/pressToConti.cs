using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressToConti : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            this.gameObject.SetActive(false);
        }
    }
}
