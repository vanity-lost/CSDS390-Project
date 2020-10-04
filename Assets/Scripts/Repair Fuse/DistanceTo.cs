using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTo : MonoBehaviour
{
    [SerializeField] GameObject fuse; 

    // Start is called before the first frame update
    void Start()
    {
        //fuses = GameObject.FindObjectsOfType<LeakCovered>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, fuse.transform.position);
        //Debug.Log(distance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Fuse")
        {
            Debug.Log(collision);
            //.collider.GetComponent<MoveFuse>().lockPlace();
        }
        //Debug.Log(collision);
    }
}
