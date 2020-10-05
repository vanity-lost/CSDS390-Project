using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] GameObject engine;
    [SerializeField] float distance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueUpdate.locked) {
            if (Input.GetKeyDown("q") & (Vector3.Distance(transform.position, engine.transform.position) < distance))
            {
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
            if (Input.GetKeyDown("o"))
            {
                SceneManager.LoadScene("Fire Extinguish");
            }
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene("End Scene");
            }
        }
    }
}
