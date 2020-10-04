using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtinguisherMove : MonoBehaviour
{
    public RectTransform Extinguisher;
    public Vector3 offset;
    public RectTransform backgroundPanel;
    public Camera cam;
    public bool takeExtinguisher;
    public Vector3 originalPos;
    public GameObject takeBoolText;

    // Start is called before the first frame update
    void Start()
    {
        takeExtinguisher = false;
        takeBoolText.GetComponent<Text>().text = "" + takeExtinguisher + "";
        originalPos = Extinguisher.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            takeExtinguisher = !takeExtinguisher;
            takeBoolText.GetComponent<Text>().text = "" + takeExtinguisher + "";
        }

        if (takeExtinguisher == true)
        {
            MoveExtinguisher();
        }
        else
        {
            Extinguisher.position = originalPos;
        }
    }

    public void MoveExtinguisher()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = backgroundPanel.position.z;
        Extinguisher.position = cam.ScreenToWorldPoint(pos);
    }
}
