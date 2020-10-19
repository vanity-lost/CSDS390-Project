using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakCovered : MonoBehaviour
{
    [SerializeField] private float slabSize = 0.3f;
    [SerializeField] private bool covered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseEnough(GameObject slab)
    {
        if (!covered)
        {
            float slabX = Mathf.Abs(slab.transform.position.x);
            float slabZ = Mathf.Abs(slab.transform.position.z);
            float leakZ = Mathf.Abs(transform.position.z);
            float leakX = Mathf.Abs(transform.position.x);
            if ((Mathf.Abs(slabZ - leakZ)) < slabSize && (Mathf.Abs(slabX - leakX)) < slabSize)
            {
                Debug.Log("True");
                FindObjectOfType<LeakTracker>().GetComponent<LeakTracker>().LeakFilled();
                covered = true;
                GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                Debug.Log("False");
            }
        }
    }
}
