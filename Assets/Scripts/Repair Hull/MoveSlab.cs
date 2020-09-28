using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlab : MonoBehaviour
{
    Vector3 mousePosition;
    bool down = false;
    bool held = false;
    bool check = true;
    [SerializeField] private float holdHeight = 7f;
    [SerializeField] private float dropSpeed = 0.007f;
    LeakCovered[] leaks;


    // Start is called before the first frame update
    void Start()
    {
        leaks = GameObject.FindObjectsOfType<LeakCovered>();
        //Debug.Log(leaks[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("q") || down) && held)             // if q down or not up, and slab in held
        {
            down = true;
            holdHeight -= dropSpeed;
            //Debug.Log("Down");
        }
        if(Input.GetKeyUp("q"))
        {
            down = false;
        }
        if ((transform.position.y <= 0.4) && check)
        {
            check = false;
            foreach (LeakCovered leak in leaks)
            {
                leak.GetComponent<LeakCovered>().CloseEnough(gameObject);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (transform.position.y > 0.4)              //slab close enough to leak
        {
            held = true;
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
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
