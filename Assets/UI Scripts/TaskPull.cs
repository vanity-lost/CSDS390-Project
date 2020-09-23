using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPull : MonoBehaviour
{
    [SerializeField] private GameObject task;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")){
            task.SetActive(true);
        }
        else if(Input.GetKeyDown("g")){
            task.SetActive(false);
        }
    }
}
