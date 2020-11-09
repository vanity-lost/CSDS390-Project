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

    private Transform sweeperTransform;
    private float rotSpeed = 300f;

    public static bool radarOpen = false;
    private bool sweeperOn = false;
    private bool iconActive = false;

    private Vector3 monsterVector = new Vector3();

    private void Awake()
    {
        //sweeperTransform = transform.Find("Radar Line");
    }

    void Update()
    {
        bool close = Closeness();

        //sweeperTransform.eulerAngles += new Vector3(0,0,-rotSpeed * Time.deltaTime);
        sweeper.transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown("e") && close == true)
        {
            Debug.Log("this is working");
            if (!radarOpen)
            {
                radarCanvas.SetActive(true);
                radarOpen = true;
                sweeperOn = true;
            }
            else
            {
                radarCanvas.SetActive(false);
                radarOpen = false;
                sweeperOn = false;
            }
        }

        if (sweeperOn)
        {
            //sweeperCanvas.transform.eulerAngles += new Vector3(0f, 0f, -rotSpeed * Time.deltaTime);
            sweeperCanvas.transform.Rotate(0f, 0f, -rotSpeed * Time.deltaTime, Space.Self);
        }

        TrackMonster();
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
            float x = (((-1f * monsterVector.x) - 100) * 10) + 475;
            float y = (monsterVector.z * 1.2f) + 235;
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
