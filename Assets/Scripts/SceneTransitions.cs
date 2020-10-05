using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// taken from https://www.youtube.com/watch?v=Qd2em_ts5vs
public class SceneTransitions : MonoBehaviour
{
    public GameObject transitionPanel;
    public Animator transitionAnim;
    public string sceneName;
    public string sceneName2;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(LoadScene(sceneName));
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            StartCoroutine(LoadScene(sceneName2)); 
        }
    }
    IEnumerator LoadScene(string s){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(s);
    }
}
