using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    enum MovementState
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private bool useMobileControls = false;

    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;

	// Use this for initialization
	void Start () {

        goLeft = false;
        goRight = false;
        goUp = false;
        goDown = false;

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
            if(goUp)
            {
                transform.Translate(0.0f, 0.0f, playerSpeed * Time.deltaTime);
            }

            if(goDown)
            {
                transform.Translate(0.0f, 0.0f, -playerSpeed * Time.deltaTime);
            }

            if(goLeft)
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            }

            if(goRight)
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    public void EnableButtonLeft()
    {
        goLeft = true;
    }

    public void EnableButtonRight()
    {
        goRight = true;
    }

    public void EnableButtonUp()
    {
        Debug.Log("Enable Button Up");

        goUp = true;
    }

    public void EnableButtonDown()
    {
        goDown = true;
    }

    public void DisableButtonMovement()
    {
        Debug.Log("Disable Button use");
        goLeft = false;
        goRight = false;
        goUp = false;
        goDown = false;
    }
}
