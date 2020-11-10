using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject sweeper;
    public GameObject label;
    public GameObject radarCanvas;
    public GameObject sweeperCanvas;
    public GameObject enemyIcon;
    //public PowerBtn powerBtn;

    private Transform sweeperTransform;
    private float rotSpeed = 250f;

    public static bool radarOpen = false;
    public static bool sweeperOn = true;
    private bool iconActive = false;
    public static bool radarOn = true;

    private Vector3 monsterVector = new Vector3();

    private void Awake()
    {
        //sweeperTransform = transform.Find("Radar Line");
    }

    void Update()
    {
        bool close = Closeness();

        //sweeperTransform.eulerAngles += new Vector3(0,0,-rotSpeed * Time.deltaTime);
        if (RadarBtn.radarOn)
        {
            sweeper.SetActive(true);
            sweeper.transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            sweeper.SetActive(false);
        }

        if (Input.GetKeyDown("e") && close == true)
        {
            //Debug.Log("this is working");
            if (!radarOpen)
            {
                radarCanvas.SetActive(true);
                radarOpen = true;
                sweeperOn = true;
                //Screen.lockCursor = false;
            }
            else
            {
                radarCanvas.SetActive(false);
                radarOpen = false;
                sweeperOn = false;
                //Screen.lockCursor = true;
            }
        }

        if (sweeperOn && RadarBtn.radarOn)
        {
            sweeperCanvas.SetActive(true);
            float rotation = sweeper.transform.localEulerAngles.z;
            //Debug.Log("rotation angle: " + rotation);
            sweeperCanvas.transform.localEulerAngles = new Vector3(0f, 0f, rotation - 110f);
            //sweeper.transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime, Space.Self);
            //sweeperCanvas.transform.eulerAngles += new Vector3(0f, 0f, -rotSpeed * Time.deltaTime);
            //sweeperCanvas.transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime, Space.Self);
            TrackMonster();
        }
        else
        {
            sweeperCanvas.SetActive(false);
            enemyIcon.SetActive(false);
            iconActive = false;
        }

        
    }

    private bool Closeness()
    {
        bool status = false;
        Vector3 playerVector = GameObject.Find("Player").transform.position;
        Vector3 radarVector = GameObject.Find("Radar").transform.position;
        float distance = Vector3.Distance(playerVector, radarVector);

        if (distance <= 2)
        {
            label.SetActive(true);
            status = true;
        }
        else
        {
            label.SetActive(false);
        }

        return status;
    }

    private void TrackMonster()
    {
        if (TempOutdoorCreature.monsterStatus)
        {
            //TempOutdoorCreature.GetMonsterLocation();
            monsterVector = TempOutdoorCreature.monsterVector;
            Debug.Log("monster x: " + monsterVector.x + " monster y: " + monsterVector.y);
            float x = (((-1 * monsterVector.x) - 100) * 10) + 785;
            float y = (monsterVector.z * 1.2f) + 350;
            //Debug.Log("x: " + (x - 475) + " y: " + (y - 235));
            enemyIcon.transform.position = new Vector3(x, y, 0);
            if (!iconActive)
            {
                enemyIcon.SetActive(true);
                iconActive = true;
            }
        }
        else
        {
            enemyIcon.SetActive(false);
            iconActive = false;
        }

    }
}
