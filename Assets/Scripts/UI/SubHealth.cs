using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubHealth : MonoBehaviour
{
    int healthNum = 100;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + healthNum + "%";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
