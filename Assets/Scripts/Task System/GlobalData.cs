using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{ 
    [SerializeField] static public bool lightSwitch = true; 
    [SerializeField] static public bool lightsOn = true;     // all light of submarine

    [SerializeField] static public bool engineBroken = false;
    [SerializeField] static public bool wiresBroken = false;
    [SerializeField] static public bool hullBroken = false;
    [SerializeField] static public bool fires = false;
    [SerializeField] static public bool fuseBroken = false;
    [SerializeField] static public bool engineOn = true;
    [SerializeField] static public bool radarOn = true;

    [SerializeField] static public bool updateEngine = false;
    [SerializeField] static public bool updateFire = false;
    [SerializeField] static public bool updateWires = false;
    [SerializeField] static public bool updateHull = false;
    [SerializeField] static public int brokenWireboxLoc = -1;

    [SerializeField] static public bool storageLocked = true;

    public static Vector3 position = new Vector3(0, -10f, 0);
    public static Quaternion rotation = new Quaternion(1, 0, 0, 1);

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
