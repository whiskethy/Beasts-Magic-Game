using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private bool useMobileControls = false;

    public AndroidJoystick joyStick;
    private PlayerAnimation anim;

    private float movementDirTemp;

    // Use this for initialization
    void Start () {
        anim = GetComponent<PlayerAnimation>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!useMobileControls)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movementDirTemp = playerSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                anim.walkForward(movementDirTemp);
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementDirTemp = -playerSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                anim.walkBackward(movementDirTemp);
            }

            if (Input.GetKey(KeyCode.D))
            {
                movementDirTemp = playerSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                anim.walkLateral(movementDirTemp);
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementDirTemp = -playerSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                anim.walkLateral(movementDirTemp);
            }

            //ugly i know, but won't be used in final version anyway. Just there for debugging
            if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)) || (Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)))
            {
                anim.stopWalking();
            }
        }
        else
        {
            transform.Translate(joyStick.InputDirection * playerSpeed * Time.deltaTime);
            anim.walk(joyStick.InputDirection * playerSpeed * Time.deltaTime);
        }
    }
}
