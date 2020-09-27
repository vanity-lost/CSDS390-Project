using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBolt : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider[] colliders;
    [SerializeField] private GameObject leftWrentch;
    [SerializeField] private GameObject rightWrentch;
    [SerializeField] private GameObject wrentch;
    [SerializeField] private GameObject button;


    bool done = false;

    [SerializeField] private float distance = 1.2f;

    Vector3 left;
    Vector3 right;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
// Debug.Log(transform.position + " " + done);
        if (done == false)
        {
            Vector3 left = leftWrentch.transform.position;
            left.y = transform.position.y;
            Vector3 right = rightWrentch.transform.position;
            right.y = transform.position.y;
            //Debug.Log(Vector3.Distance(left, transform.position));
            if (Vector3.Distance(left, transform.position) < distance)
            {
                if (Vector3.Distance(right, transform.position) < distance)
                {
                    done = true;
                    wrentch.GetComponent<MovableWrentch>().WrentchLookAround(gameObject);
                    button.GetComponent<PressButton>().BoltDone();
                }
            }
        }
    }






}


