using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public Animator transitionAnim;
    public void PlayGame () {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene(){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
