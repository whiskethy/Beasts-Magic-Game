using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.Networking;
public class NetOp : NetworkBehaviour {

    //[SerializeField]
    //private bool player2 = false;
    //private PlayerData playerData;
    public GameObject cam;
    private UnityStandardAssets.Cameras.AutoCam theCamera;

    //public AndroidJoystick joyStick;
    //private PlayerAnimation anim;
    public GameObject otherPlayer;

    //private float movementDirTemp;

    static GameObject goClient;
    static GameObject goServer;

    Text healthText1;
    Text healthText2;
    Slider slid1;
    Slider slid2;
    Slider[] slider;
   
    // Use this for initialization
    void Start()
    {
        //theCamera = Camera.main.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        theCamera = cam.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>();

        //theCamera = Camera.main.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>();

        //anim = GetComponent<PlayerAnimation>();
        //playerData = GetComponent<PlayerData>();
        //otherPlayer = GetComponent<Movement>().otherPlayer;
        healthText1 = GameObject.Find("Player1HealthText").GetComponent<Text>();
        healthText2 = GameObject.Find("Player2HealthText").GetComponent<Text>();
 
        slid1 = GameObject.Find("SliderA").GetComponents<Slider>()[0];
        slid2 = GameObject.Find("SliderB").GetComponents<Slider>()[0];
        slid2.maxValue = 150;
        slid1.maxValue = 150;
        otherPlayer = null;
    }
    public GameObject getOtherPlayer()
    {
        return otherPlayer;
    }
    public GameObject getServerPlayer()
    {
        return goServer;
    }
    public GameObject getClientPlayer()
    {
        return goClient;
    }
    public override void OnStartClient()
    {
        if (gameObject.Equals(goServer)) return;

        goClient = gameObject;
       // goClient.tag = "ClientPlayer";
        goClient.name = "ClientPlayer";

    }

    public override void OnStartServer()
    {
        if (goServer == null)
        {

        
            goServer = gameObject;
            //goServer.tag = "ServerPlayer";
        }
    }

    [ClientRpc]
    public void RpcSetOther(GameObject gameObject)
    {
        if (goServer == null)
            goServer = gameObject;
    }


    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        if (goClient != null)
        {
            healthText2.text = goClient.GetComponent<PlayerData>().currentHealth.ToString();
            if (slid1 != null)
                slid2.value = goClient.GetComponent<PlayerData>().currentHealth;
        }

        if (goServer != null)
        {
            
            healthText1.text = goServer.GetComponent<PlayerData>().currentHealth.ToString();
            if(slid1!=null)
                slid1.value = goServer.GetComponent<PlayerData>().currentHealth;

        }

        if (gameObject.Equals(goServer))
        {
            if (theCamera.Target == null)
            {
                //theCamera.setTarget(gameObject.transform);

            }
            if (goClient != null)
            {
                //GetComponent<Movement>().setOther(goClient);
                //Debug.Log("***Other(Client)="+goClient);
                //GetComponent<Movement>().otherPlayer=goClient;
                otherPlayer = goClient;
            }
        }
        if (gameObject.Equals(goClient))
        {
            if (theCamera.Target == null)
            {
                //theCamera.setTarget(gameObject.transform);
            }
            if (goServer != null)
            {
                //GetComponent<Movement>().setOther(goServer);
                //Debug.Log("***Other(Server)=" + goServer);
                //GetComponent<Movement>().otherPlayer=goServer;
                otherPlayer = goServer;
            }
        }
        if (isServer && goServer != null)
            RpcSetOther(goServer);

    }
    public override void OnStartLocalPlayer()
    {
        //gameObject.tag = "Player2";
        gameObject.transform.Find("Player1Icon").GetComponent<MeshRenderer>().material.color = Color.blue;

        Camera.main.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>().setTarget(gameObject.transform);
    }
}
