using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWrentch : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 offset;
    [SerializeField] private GameObject target;
    private bool lockPlace;
    private float spinSpeed = 200f;
    private float moveDownSpeed = 0.002f;
    private float timeBalance = 250f;

    void Start()
    {
        Cursor.visible = true;
    }

    private void OnMouseDrag()
    {
        if (lockPlace == false)
        {
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = -8f;
            }
            transform.position = mousePosition;
        }
        else
        {
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = -8f;
            }
            Vector3 difference = mousePosition - target.transform.position;
            Vector3 differenceWretch = transform.position - target.transform.position;
            float angle = Vector3.Angle(difference, transform.forward);
            float angleWretch = Vector3.Angle(differenceWretch, transform.up);
            angle = -angle;
            angleWretch = -angleWretch;
            if (angle > angleWretch)
            {
                GetComponent<AudioSource>().Play();
                Vector3 boltPosition = target.transform.position;
                transform.RotateAround(boltPosition, Vector3.up, spinSpeed * Time.deltaTime);
                target.transform.position = new Vector3(boltPosition.x, boltPosition.y - (moveDownSpeed * Time.deltaTime * timeBalance), boltPosition.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - (moveDownSpeed * Time.deltaTime * timeBalance), transform.position.z);
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }
            if (-1 < transform.rotation.y & transform.rotation.y < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                lockPlace = false;
            }
        }
    }


    public void WrentchLookAround(GameObject bolt)
    {
        lockPlace = true;
        target = bolt;
    }
}
