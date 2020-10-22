using UnityEngine;

public class MoveFuse : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] bool status = true;
    [SerializeField] float distanceLock = 0.2f;
    [SerializeField] bool lockPlace = false;
    GameObject[] fuses;
    GameObject slot= null;
    private bool taskDone = false;

    // Start is called before the first frame update
    void Start()
    {
        fuses = GameObject.FindGameObjectsWithTag("Fuse");
        if (transform.parent != null)
        {
            slot = transform.parent.GetChild(1).gameObject;
        }
        //Debug.Log(fuses);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDrag()
    {
        if (Creator.finished == false)
        {
            //Debug.Log("Fuse Clicked");
            if (slot != null)
            {
                slot.GetComponent<FuseHolder>().InPlace(false);
            }
            slot = null;
            //held = true;
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = transform.position.y;
            }
            transform.position = mousePosition;
            //Gizmos.DrawWireSphere(mousePosition, 2.0f);
        }
    }

    public void OnMouseUp()
    {
        if (Creator.finished == false)
        {
            //Debug.Log("Mouse Up");
            foreach (GameObject fuse in fuses)
            {
                float distance = Vector3.Distance(transform.position, fuse.transform.position);
                //Debug.Log(distance);
                if (distance < distanceLock)
                {
                    slot = fuse;
                    fuse.GetComponent<FuseHolder>().InPlace(status);
                    Debug.Log("In place");
                }
            }
        }
    }

    public void Status(bool status)
    {
        this.status = status;
    }


}
