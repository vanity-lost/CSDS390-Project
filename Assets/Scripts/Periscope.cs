using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Periscope : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "periscope")
                {
                    Debug.Log("Periscope Hit");
                    SceneManager.LoadScene("Periscope View");
                    Debug.Log("Loading Environment Scene");
                }
            }
        }

        //if (Physics.Raycast (ray, outhit))
        //{
        //    if (hit.transform.name == "Parascope:pCylinder21") {
        //        SceneManager.LoadScene("Environment");
        //    }
        //}
    }
}
