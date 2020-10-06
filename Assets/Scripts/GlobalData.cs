using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{ 
    [SerializeField] static public bool lights = true;
    [SerializeField] static public bool engineBroken = false;
    [SerializeField] static public bool wiresBroken = false;
    [SerializeField] static public bool hullBroken = false;
    [SerializeField] static public bool fires = false;
    [SerializeField] static public bool fuseBroken = false;
    [SerializeField] static public bool storageLocked = false;
    [SerializeField] static public bool updateEngine = false;


    private void Start()
    {
        fuseBroken = true;
        DontDestroyOnLoad(this.gameObject);
    }

}
