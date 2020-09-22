using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpen : MonoBehaviour
{

    public GameObject Panel;
    public GameObject PassBox;
    public GameObject NumSuccess;

    public void OpenPanel()
    {
        if (Panel != null)
        {

            PassBox.GetComponent<Text>().text = "";
            NumSuccess.GetComponent<Text>().text = "0";
            Panel.SetActive(true);
            Debug.Log("panel set active");
            Debug.Log(Panel.activeSelf.ToString());


        }
        else
        {
            Debug.Log("panel==null!");
        }
    }
}
