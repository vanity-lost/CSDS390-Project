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
        bool status = closeness();
        if (Input.GetMouseButtonDown(1) && status == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "periscope")
                {
                    Debug.Log("Periscope Hit");
                    SceneManager.LoadScene("Periscope View");
                    // GetComponent("Dialogue Controller").enabled = false;
                    Debug.Log("Loading Environment Scene");
                }
            }
        }
    }

    private bool closeness()
    {
        bool status = false;
        Vector3 playerVector = GameObject.Find("Player").transform.position;
        Vector3 periscopeVector = GameObject.Find("periscope").transform.position;
        float distance = Vector3.Distance(playerVector, periscopeVector);

        if (distance <= 2)
        {
            status = true;
        }

        return status;
    }
}
