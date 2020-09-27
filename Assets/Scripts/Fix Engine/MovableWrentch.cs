using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWrentch : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 offset;
    [SerializeField] private GameObject target;
    private int targetNumber = 0;
    private bool lockPlace;
    [SerializeField] private float spinSpeed;
    [SerializeField] private bool notAssigned = true;
    float last = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lockPlace);
        //Debug.Log(Input.mousePosition);
        //Debug.Log(Camera.main.WorldToScreenPoint(Input.mousePosition));
        //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void OnMouseDrag()
    {
        if (lockPlace == false)
        {
            //Debug.Log("Dragging");
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = -8f;
            }
            //Debug.Log(mousePosition);
            transform.position = mousePosition;
        }
        else
        {
            //bool notAssigned = true;
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = -8f;
            }
            //Debug.Log(mousePosition);
            Vector3 difference = mousePosition - target.transform.position;
            Vector3 differenceWretch = transform.position - target.transform.position;
            float angle = Vector3.Angle(difference, transform.forward);
            float angleWretch = Vector3.Angle(differenceWretch, transform.up);
            angle = -angle;
            angleWretch = -angleWretch;
            //Debug.Log(angle);
            Debug.Log(angleWretch);
            //Debug.Log(last);
            if (notAssigned)
            {
                last = angle;
                notAssigned = false;
            }
            else
            {
                if (angle > angleWretch)
                {
                    //last = angle;
                    //Debug.Log(difference);
                    transform.RotateAround(target.transform.position, Vector3.up, 200 * Time.deltaTime);
                }
                last = angle;
                if (-1 < transform.rotation.y & transform.rotation.y < 0)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                    lockPlace = false;
                    //targetNumber = targetNumber + 1;
                }
            }

            /*transform.RotateAround(target.transform.position, Vector3.up, 80 * Time.deltaTime);
            if (-1 < transform.rotation.y & transform.rotation.y < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                lockPlace = false;
                //targetNumber = targetNumber + 1;
            }
            */
        }
    }


    public void WrentchLookAround(GameObject bolt)
    {
        lockPlace = true;
        target = bolt;
    }
}
