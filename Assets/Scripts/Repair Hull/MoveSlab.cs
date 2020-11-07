using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlab : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 actualPosition;
    bool down = false;
    bool held = false;
    bool check = true;
    [SerializeField] private float holdHeight = 7f;
    [SerializeField] private float dropSpeed = 0.0156f;
    //private float deltaTimeCancel = 209f;
    LeakCovered[] leaks;

    LeakTracker leakTracker;


    void Start()
    {
        StartCoroutine(LateStart(0.5f));
        leakTracker = FindObjectOfType<LeakTracker>().GetComponent<LeakTracker>();
        //leaks = GameObject.FindObjectsOfType<LeakCovered>();
        //Debug.Log(leaks[0].transform.position);
    }


    void Update()
    {
        //Debug.Log(Time.deltaTime);
        if((Input.GetKeyDown("q") || down) && held)             // if q down or not up, and slab in held
        {
            Cursor.visible = false;
            down = true;
            holdHeight -= dropSpeed;// * Time.deltaTime * deltaTimeCancel;
            //transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
            transform.localScale = transform.localScale * 0.9982f;//* Time.deltaTime * deltaTimeCancel;
            //Debug.Log("Down");
        }
        if(Input.GetKeyUp("q"))
        {
            down = false;
        }
        if ((transform.position.y <= 0.4) && check)
        {
            Cursor.visible = true;
            GetComponent<AudioSource>().Play(); 
            check = false;
            leakTracker.OutofSlabs();
            foreach (LeakCovered leak in leaks)
            {
                leak.GetComponent<LeakCovered>().CloseEnough(gameObject);
            }
        }
    }

    IEnumerator LateStart(float wait)
    {
        yield return new WaitForSeconds(wait);
        leaks = GameObject.FindObjectsOfType<LeakCovered>();
    }

    private void OnMouseDrag()
    {
        if (transform.position.y > 0.4)              //slab low enough in Y
        {
            held = true;
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                actualPosition = hit.point;
                mousePosition.y = holdHeight;
            }
            transform.position = mousePosition;
        }
        else
        {
            held = false;
        }
    }

    public void OnMouseUp()
    {
        held = false;
    }
}
