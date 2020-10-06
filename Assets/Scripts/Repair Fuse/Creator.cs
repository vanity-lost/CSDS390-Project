using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creator : MonoBehaviour
{
    private GameObject[] fuseHolder;
    private int broken = 0;
    private int number = 0;
    private GameObject fuse;
    private GameObject spotHolder;

    // Start is called before the first frame update
    void Start()
    {
        fuseHolder = GameObject.FindGameObjectsWithTag("FuseHolder");
        float randNum;
        foreach (GameObject holder in fuseHolder) {
            randNum = Random.Range(-2, 5);
            Debug.Log(randNum);
            number++;
            if (randNum > 0 | (number == 3 & broken == 0))
            {
                broken = broken + 1;
                fuse = holder.transform.GetChild(0).gameObject;
                spotHolder = holder.transform.GetChild(1).gameObject;
                fuse.GetComponent<MoveFuse>().Status(false);
                spotHolder.GetComponent<FuseHolder>().InPlace(false);
                //Debug.Log("Broke One");
            }
        }
    }


    public void Complete()
    {
        bool done = true;
        foreach (GameObject holder in fuseHolder)
        {
            bool inPlace = holder.transform.GetChild(1).gameObject.GetComponent<FuseHolder>().InPlace();
            //Debug.Log(inPlace);
            if (holder.transform.GetChild(1).gameObject.GetComponent<FuseHolder>().InPlace() == false)
            {
                done = false;
            }
        }
        if (done)
        {
            GlobalData.fuseBroken = false;
            SceneManager.LoadScene("Main");
        }
    }
}
