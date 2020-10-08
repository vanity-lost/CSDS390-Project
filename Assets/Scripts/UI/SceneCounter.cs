using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCounter : MonoBehaviour
{
    //public GameObject sceneController;
    static int counter = 0;


    void Start()
    {
        counter++;
    }

    void Update()
    {
        if (counter == 1) {
            GameObject.Find("Dialogue Controller").SetActive(true);
        }
        else
        {
            GameObject.Find("Dialogue Controller").SetActive(false);
        }
    }
}
