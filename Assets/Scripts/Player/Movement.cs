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

    // Use this for initialization
    void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {

        if (!useMobileControls)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0.0f, 0.0f, playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0.0f, 0.0f, -playerSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        else
        {
            transform.Translate(joyStick.InputDirection * playerSpeed * Time.deltaTime);
        }
    }
}
