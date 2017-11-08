using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    //[SerializeField] private bool useMobileControls = false;
    [SerializeField] private bool player2 = false;
    private PlayerData playerData;

    public AndroidJoystick joyStick;
    private PlayerAnimation anim;
    public GameObject otherPlayer;

    private float movementDirTemp;

    enum Id {No, Client, Server};

    float x1, z1;
    float x2, z2;

    int myID = 0;

    // Use this for initialization
    void Start () {
        anim = GetComponent<PlayerAnimation>();
        playerData = GetComponent<PlayerData>();

    }

    public override void OnStartClient()
    {
        myID += 1;  
    }

    public override void OnStartServer()
    {
        myID += 1;
    }
    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }


        if (!player2)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movementDirTemp = playerData.movementSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                transform.LookAt(otherPlayer.transform);
                anim.walkForward(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                movementDirTemp = -playerData.movementSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                transform.LookAt(otherPlayer.transform);
                anim.walkBackward(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                movementDirTemp = playerData.movementSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                transform.LookAt(otherPlayer.transform);
                anim.walkLateral(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                movementDirTemp = -playerData.movementSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                transform.LookAt(otherPlayer.transform);
                anim.walkLateral(movementDirTemp, playerData.movementSpeed);
            }

            //ugly i know, but won't be used in final version anyway. Just there for debugging
            else if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)) || (Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)))
            {
                anim.stopWalking();
            }
            else
            {
                transform.Translate(joyStick.InputDirection * playerData.movementSpeed * Time.deltaTime);
                transform.LookAt(otherPlayer.transform);
                anim.walk(joyStick.InputDirection * playerData.movementSpeed * Time.deltaTime, playerData.movementSpeed);
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movementDirTemp = playerData.movementSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                transform.LookAt(otherPlayer.transform);
                anim.walkForward(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movementDirTemp = -playerData.movementSpeed * Time.deltaTime;

                transform.Translate(0.0f, 0.0f, movementDirTemp);
                transform.LookAt(otherPlayer.transform);
                anim.walkBackward(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementDirTemp = playerData.movementSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                transform.LookAt(otherPlayer.transform);
                anim.walkLateral(movementDirTemp, playerData.movementSpeed);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movementDirTemp = -playerData.movementSpeed * Time.deltaTime;

                transform.Translate(movementDirTemp, 0.0f, 0.0f);
                transform.LookAt(otherPlayer.transform);
                anim.walkLateral(movementDirTemp, playerData.movementSpeed);
            }

            //ugly i know, but won't be used in final version anyway. Just there for debugging
            else if ((Input.GetKeyUp(KeyCode.UpArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)) || (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.RightArrow)))
            {
                anim.stopWalking();
            }

        }

    }
}
