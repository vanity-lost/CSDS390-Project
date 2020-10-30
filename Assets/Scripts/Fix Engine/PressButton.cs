using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    bool buttonPressed;
    [SerializeField] private int numBolts = 3;

    int boltsDone = 0;

    public void BoltDone()
    {
        boltsDone++;
    }

    private void OnMouseDown()
    {
        if (boltsDone == numBolts)
        {
            GetComponent<AudioSource>().Play();
            buttonPressed = true;
            GlobalData.engineBroken = false;
            ESCDectect.gameIsPaused = false;
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Main");
    }
}
