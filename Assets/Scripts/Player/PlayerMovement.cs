using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 4.0f;
    public float sprintspeed = 4.0f * 1.5f;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ESCDectect.gameIsPaused) {
            movespeed = 0.0f;
        } else {
            movespeed = 4.0f;
        }
        float xMovement = Input.GetAxis("Horizontal") * movespeed;
        float yMovement = Input.GetAxis("Vertical") * movespeed;
        Vector3 moving = new Vector3(xMovement, 0, yMovement);
        
        moving = Vector3.ClampMagnitude(moving, movespeed);
        moving = moving * Time.deltaTime;
        moving = transform.TransformDirection(moving);

        character.Move(moving);
    }

}
