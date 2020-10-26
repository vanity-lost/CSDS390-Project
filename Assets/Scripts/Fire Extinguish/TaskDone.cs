using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskDone : MonoBehaviour
{
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject takeBoolText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }

        if (!Fire1.activeSelf && !Fire2.activeSelf && !Fire3.activeSelf)
        {
            //takeBoolText.GetComponent<Text>().text = "False";
            StartCoroutine(EndTask());
        }
    }

    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("all fire are put down");
        GlobalData.fires = false;
        //GlobalData.updateFire = false;
        SceneManager.LoadScene("Main");
    }
}
