using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelClose : MonoBehaviour
{
    public GameObject Panel;
    public GameObject NumSuccess;

    public void ClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
            NumSuccess.GetComponent<Text>().text = "0";
        }
    }
}
