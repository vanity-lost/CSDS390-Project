using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("fix Engine");
            SceneManager.LoadScene("Fix Engine");
        }
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene("Connect Wire");
        }
        if (Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene("Storage Room");
        }
        if (Input.GetKeyDown("h"))
        {
            SceneManager.LoadScene("Fix Hull");
        }
        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene("End Scene");
        }
    }
}
