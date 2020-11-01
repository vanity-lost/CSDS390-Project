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

    void Start()
    {
        fuses = GameObject.FindGameObjectsWithTag("Fuse");
        if (transform.parent != null)
        {
            slot = transform.parent.GetChild(1).gameObject;
        }
    }



    private void OnMouseDrag()
    {
        if (Creator.finished == false)
        {
            if (slot != null)
            {
                slot.GetComponent<FuseHolder>().InPlace(false);
                GetComponent<AudioSource>().Play();
            }
            slot = null;
            Camera.main.WorldToScreenPoint(transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mousePosition = hit.point;
                mousePosition.y = transform.position.y;
            }
            transform.position = mousePosition;
        }
    }

    public void OnMouseUp()
    {
        if (Creator.finished == false)
        {
            foreach (GameObject fuse in fuses)
            {
                float distance = Vector3.Distance(transform.position, fuse.transform.position);
                if (distance < distanceLock)
                {
                    slot = fuse;
                    fuse.GetComponent<FuseHolder>().InPlace(status);
                }
            }
        }
    }

    public void Status(bool status)
    {
        this.status = status;
    }


}
