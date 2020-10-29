using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeakTracker : MonoBehaviour
{
    [SerializeField] private int numLeaks = 4;
    [SerializeField] private int numSlabs = 5;
    [SerializeField] private GameObject leak1;
    [SerializeField] private GameObject leak2;
    [SerializeField] private float distance = 5f;
    private List<GameObject> leaks = new List<GameObject>();
    private GameObject newLeak;
    private float minimumZ = -5.5f;
    private float maxZ = 5.5f;
    private float minimumX = -10.5f;
    private float maxX = 10.5f;
    ParticleSystem ps;


    void Start()
    {
        int x = 0;
        while (x < numLeaks)
        {
            float zPos = Random.Range(minimumZ, maxZ);
            float xPos = Random.Range(minimumX, maxX);
            float yPos = 0.01f;
            Vector3 position = new Vector3(xPos, yPos, zPos);
            bool acceptable = true;
            if (x == 0)
            {
                x = x + 1;
                if (Random.Range(0, 2) == 1)
                {
                    newLeak = Instantiate(leak1);
                }
                else
                {
                    newLeak = Instantiate(leak2);
                }
                //Debug.Log(newLeak);
                var e = newLeak.GetComponent<ParticleSystem>().emission;
                e.rateOverTime = Random.Range(0, 20);
                newLeak.transform.position = position;
                newLeak.transform.Rotate(0, Random.Range(0, 360), 0);
                //Debug.Log(leaks);
                leaks.Add(newLeak);
                //Debug.Log(leaks);
            }
            else
            {
                foreach (GameObject leakMade in leaks)
                {
                    if (Vector3.Distance(leakMade.transform.position, position) < distance)
                    {
                        acceptable = false;
                    }
                }
                if (acceptable)
                {
                    x = x + 1;
                    if (Random.Range(0, 2) == 1)
                    {
                        newLeak = Instantiate(leak1);
                    }
                    else
                    {
                        newLeak = Instantiate(leak2);
                    }
                    var e = newLeak.GetComponent<ParticleSystem>().emission;
                    e.rateOverTime = Random.Range(0, 20);
                    newLeak.transform.position = position;
                    newLeak.transform.Rotate(0, Random.Range(0, 360), 0);
                    newLeak.transform.position = position;
                    leaks.Add(newLeak);
                }
            }
        }
    }

    public void LeakFilled()
    {
        numLeaks = numLeaks - 1;
        if (numLeaks == 0)
        {
            ESCDectect.gameIsPaused = false;
            GlobalData.hullBroken = false;
            SceneManager.LoadScene("Main");
        }
    }

    public void OutofSlabs()
    {
        numSlabs = numSlabs - 1;
        if (numSlabs == 0 && numLeaks != 0)
        {
            Debug.Log("Out of Slabs");
            ESCDectect.gameIsPaused = false;
            SceneManager.LoadScene("Main");
        }
    }
}
