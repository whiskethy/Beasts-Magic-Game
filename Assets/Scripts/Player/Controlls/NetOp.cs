using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.Networking;
public class NetOp : NetworkBehaviour {

    public GameObject cam;
    private UnityStandardAssets.Cameras.AutoCam theCamera;

    public GameObject otherPlayer;

    static GameObject goClient;
    static GameObject goServer;

    Text healthText1;
    Text healthText2;
    Slider slid1;
    Slider slid2;
    Slider[] slider;
   
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        theCamera = cam.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>();

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
        goClient.name = "ClientPlayer";

    }

    public override void OnStartServer()
    {
        if (goServer == null)
        {
            goServer = gameObject;
        }
    }

    [ClientRpc]
    public void RpcSetOther(GameObject gameObject)
    {
        if (goServer == null)
            goServer = gameObject;
    }

    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        if (goClient != null)
        {
            healthText2.text = goClient.GetComponent<PlayerData>().currentHealth.ToString();
            if (slid1 != null)
            {
                slid2.value = goClient.GetComponent<PlayerData>().currentHealth;
            }
        }

        if (goServer != null)
        {
            healthText1.text = goServer.GetComponent<PlayerData>().currentHealth.ToString();
            if (slid1 != null)
            {
                slid1.value = goServer.GetComponent<PlayerData>().currentHealth;
            }
        }

        if (gameObject.Equals(goServer))
        {
            if (goClient != null)
            {
                otherPlayer = goClient;
            }
        }
        if (gameObject.Equals(goClient))
        {
            if (goServer != null)
            {
                otherPlayer = goServer;
            }
        }
        if (isServer && goServer != null)
            RpcSetOther(goServer);

    }
    public override void OnStartLocalPlayer()
    {
        gameObject.transform.Find("Player1Icon").GetComponent<MeshRenderer>().material.color = Color.blue;
        gameObject.transform.Find("PersonalSpace").GetComponent<MeshRenderer>().material.color = Color.blue;

        Camera.main.GetComponentInParent<UnityStandardAssets.Cameras.AutoCam>().setTarget(gameObject.transform);
    }
}
