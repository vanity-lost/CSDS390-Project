using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public GameObject panel;

    public void PlayGame () {
        StartCoroutine(transition());
    }

    IEnumerator transition(){
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main");
    }
}
