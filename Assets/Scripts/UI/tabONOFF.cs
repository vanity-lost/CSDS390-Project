using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabONOFF : MonoBehaviour
{
    public GameObject TaskPanel;

    public void onClick(){
        TaskPanel.SetActive(!TaskPanel.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            onClick();
        }
    }
}
