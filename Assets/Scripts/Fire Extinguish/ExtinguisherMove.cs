using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtinguisherMove : MonoBehaviour
{
    public RectTransform Extinguisher;
    public GameObject FireExtinguisher;
    public Vector3 offset;
    public float zCoord;
    public RectTransform backgroundPanel;
    public bool takeExtinguisher;
    public Vector3 extinguisherOriginalPos;//3d model's original pos
    public GameObject takeBoolText;
    public float distanceFromCam;
    //public float distanceFromCam = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        takeExtinguisher = false;
        takeBoolText.GetComponent<Text>().text = "" + takeExtinguisher + "";
        extinguisherOriginalPos = FireExtinguisher.transform.position;

        Vector3 tovector = transform.position - Camera.main.transform.position;
        Vector3 lineardistance = Vector3.Project(tovector, Camera.main.transform.forward);
        distanceFromCam = lineardistance.magnitude;
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
            FireExtinguisher.transform.position = extinguisherOriginalPos;
        }
    }

    public void MoveExtinguisher()
    {
        //Vector3 mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z+transform.position.z);
        //Vector3 objposition = Camera.main.ScreenToWorldPoint(mousepos);
        //transform.position = objposition;
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = distanceFromCam;
        transform.position = Camera.main.ScreenToWorldPoint(mousepos)+offset;
        


    }
}
