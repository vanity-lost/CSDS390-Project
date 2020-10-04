using UnityEngine;

public class MoveFuse : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] float distanceLock = 0.2f;
    [SerializeField] bool lockPlace = false;
    GameObject[] fuses;

    // Start is called before the first frame update
    void Start()
    {
        fuses = GameObject.FindGameObjectsWithTag("Fuse");
        Debug.Log(fuses);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDrag()
    {
        if (lockPlace == false) {
        //held = true;
        Camera.main.WorldToScreenPoint(transform.position);    
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            mousePosition.y = 1.0f;
        }
        transform.position = mousePosition;
        //Gizmos.DrawWireSphere(mousePosition, 2.0f);

        }
    }

    public void OnMouseUp()
    {
        //Debug.Log("Mouse Up");
        foreach (GameObject fuse in fuses)
        {
            float distance = Vector3.Distance(transform.position, fuse.transform.position);
            //Debug.Log(distance);
            if (distance < distanceLock)
            {
                Debug.Log("In place");
            }
        }
    }

/*
    public void LockPlace()
    {
        lockPlace = true;
        Debug.Log("Lock");
    }
    */
}
