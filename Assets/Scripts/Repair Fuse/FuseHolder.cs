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

    void Start()
    {
        topSparks = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        bottomSparks = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        status = transform.GetChild(2).gameObject.GetComponent<Light>();
        background = transform.GetChild(3).gameObject.GetComponent<Light>();
        topSparks.Stop();
        bottomSparks.Stop();
    }

    void Update()
    {
        if (satisfied)          //checks if good fuse in this slot
        {
            if (on)             //checks if holder already set to good, if not sets it to good
            {
                on = false;
                topSparks.Stop();
                bottomSparks.Stop();
                status.color = Color.green;
                background.color = Color.green;
            }
        }
        else                   //if good fuse is in this slot
        {
            if (on == false)    //checks if holder already set to bad, if not sets it to bad
            {
                on = true;
                topSparks.Play();
                bottomSparks.Play();
                status.color = Color.red;
                background.color = Color.red;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void InPlace(bool condition)
    {
        satisfied = condition;
        if (condition)
        {
            GetComponent<AudioSource>().Stop();
            GameObject.FindObjectOfType<Creator>().Complete();
        }
    }

    public bool InPlace()
    {
        return satisfied;
    }




}
