using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseHolder : MonoBehaviour
{
    private ParticleSystem topSparks;
    private ParticleSystem bottomSparks;
    private Light status;
    private Light background;
    [SerializeField] private bool satisfied = true;
    private bool on;

    // Start is called before the first frame update
    void Start()
    {
        topSparks = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        bottomSparks = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        status = transform.GetChild(2).gameObject.GetComponent<Light>();
        background = transform.GetChild(3).gameObject.GetComponent<Light>();
        topSparks.Stop();
        bottomSparks.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (satisfied)
        {
            if (on)
            {
                on = false;
                topSparks.Stop();
                bottomSparks.Stop();
                status.color = Color.green;
                background.color = Color.green;
            }
        }
        else
        {
            if (on == false)
            {
                on = true;
                //Debug.Log("Let there be music");
                topSparks.Play();
                bottomSparks.Play();
                status.color = Color.red;
                background.color = Color.red;
            }
        }
    }

    public void InPlace(bool condition)
    {
        satisfied = condition;
        if (condition)
        {
            GameObject.FindObjectOfType<Creator>().Complete();
        }
    }

    public bool InPlace()
    {
        return satisfied;
    }




}
