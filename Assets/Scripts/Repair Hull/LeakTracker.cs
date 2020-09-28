using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeakTracker : MonoBehaviour
{
    [SerializeField] private int leaks = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeakFilled()
    {
        leaks = leaks - 1;
        if (leaks == 0)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
