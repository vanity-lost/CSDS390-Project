using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Periscope : MonoBehaviour
{
    public Camera periscope;
    public Camera main;
    public GameObject label;

    public static bool periscopeView = false;

    void Update()
    {
        bool close = closeness();
        
        if (Input.GetKeyDown("e") && close == true)
        {
            if (!periscopeView)
            {
                Debug.Log("loading periscope view");
                periscope.gameObject.SetActive(true);
                main.gameObject.SetActive(false);
                periscopeView = true;
            }
            else
            {
                Debug.Log("loading main scene");
                main.gameObject.SetActive(true);
                periscope.gameObject.SetActive(false);
                periscopeView = false;
            }

            //SceneManager.LoadScene("Periscope View");
            //Debug.Log("loading periscope view");
            //Cursor.lockState = CursorLockMode.None;


            //ESCDectect.gameIsPaused = true;
            //SceneManager.LoadScene("Periscope View");
            //Debug.Log("loading periscope view");
            //Cursor.lockState = CursorLockMode.None;
        }
        //if (Input.GetMouseButtonDown(1) && status == true)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.name == "periscope")
        //        {
        //            Debug.Log("Periscope Hit");
        //            SceneManager.LoadScene("Periscope View");
        //            // GetComponent("Dialogue Controller").enabled = false;
        //            Debug.Log("Loading Environment Scene");
        //        }
        //    }
        //}
    }

    private bool closeness()
    {
        bool status = false;
        Vector3 playerVector = GameObject.Find("Player").transform.position;
        Vector3 periscopeVector = GameObject.Find("Periscope").transform.position;
        float distance = Vector3.Distance(playerVector, periscopeVector);

        if (distance <= 2)
        {
            status = true;
            label.SetActive(true);
        }
        else
        {
            label.SetActive(false);
        }

        return status;
    }
}
