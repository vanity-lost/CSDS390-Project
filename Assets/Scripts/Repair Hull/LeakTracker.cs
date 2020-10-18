using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LeakTracker : MonoBehaviour
{
    [SerializeField] private int numLeaks = 4;
    [SerializeField] private GameObject leak;
    [SerializeField] private float distance = 0.5f;
    private List<GameObject> leaks = new List<GameObject>();
    private GameObject newLeak;
    private float minimumZ = -6.5f;
    private float maxZ = 6.5f;
    private float minimumX = -11.5f;
    private float maxX = 11.5f;


    // Start is called before the first frame update
    void Start()
    {
        int x = 0;
        while (x < numLeaks)
        {
            float zPos = Random.Range(minimumZ, maxZ);
            float xPos = Random.Range(minimumX, maxX);
            float yPos = -0.6f;
            Vector3 position = new Vector3(xPos, yPos, zPos);
            bool acceptable = true;
            if (x == 0)
            {
                x = x + 1;
                newLeak = Instantiate(leak);
                newLeak.transform.position = position;
                Debug.Log(leaks);
                leaks.Add(newLeak);
                Debug.Log(leaks);
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
                    newLeak = Instantiate(leak);
                    newLeak.transform.position = position;
                    leaks.Add(newLeak);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeakFilled()
    {
        numLeaks = numLeaks - 1;
        if (numLeaks == 0)
        {
            GlobalData.hullBroken = false;
            SceneManager.LoadScene("Main");
        }
    }
}
