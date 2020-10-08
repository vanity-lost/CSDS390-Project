using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabONOFF : MonoBehaviour
{
    public GameObject Tab;
    
    public void onClick(){
        Tab.SetActive(!Tab.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            Tab.SetActive(!Tab.activeSelf);
        }
    }
}
