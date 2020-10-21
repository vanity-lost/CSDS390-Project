using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCredits : MonoBehaviour
{
    float timer = 0;
    public GameObject Credits;
    public GameObject PausePage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 20) {
            PausePage.SetActive(true);
            Credits.SetActive(false);
        }
    }
}
