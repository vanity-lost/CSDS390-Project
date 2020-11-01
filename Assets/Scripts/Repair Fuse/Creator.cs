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
    [SerializeField] private GameObject fuseCover;
    public static bool finished = false;

    void Start()
    {
        finished = false;
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
            }
        }
    }


    public void Complete()
    {
        bool done = true;
        foreach (GameObject holder in fuseHolder)
        {
            bool inPlace = holder.transform.GetChild(1).gameObject.GetComponent<FuseHolder>().InPlace();
            if (inPlace == false)
            {
                done = false;
            }
        }
        if (done)
        {
            GlobalData.fuseBroken = false;
            finished = true;
            StartCoroutine(EndTask());
        }
    }

    IEnumerator EndTask()
    {
        Debug.Log("Task Ending");
        yield return new WaitForSeconds(0.1f);
        fuseCover.GetComponent<Animator>().SetBool("Done", true);
        yield return new WaitForSeconds(1.2f);
        GlobalData.fuseBroken = false;
        ESCDectect.gameIsPaused = false;
        SceneManager.LoadScene("Main");
    }
}
