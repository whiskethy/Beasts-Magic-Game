using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.ComponentModel;
using System;
public class GameTime : NetworkBehaviour {
    [SyncVar]
    public int iTime;
    public int timeLimited;
    int s;
    int hight;
    int width;
    Text timeText;
    Text testText;

    bool isStart;

    //Text healthText1;
    //Text healthText2;

    DateTime  now;
    NetworkManagerHUD hud;

    // Use this for initialization
    void Start () {
 
        
        iTime = 0;
        //healthText1 = GameObject.Find("Player1HealthText").GetComponent<Text>();
        //healthText2 = GameObject.Find("Player2HealthText").GetComponent<Text>();
        timeText = GameObject.Find("GameTimeText").GetComponent<Text>();
        //hud = NetworkManager.singleton.GetComponent<NetworkManagerHUD>();
        //if (hud == null)
        //{
        //    return;
        //}

        isStart = true; 
        timeText.text = "00";
        iTime = 0;
        //if(timeLimited==0)
            timeLimited = 90;

    }



    private void OnDisconnectedFromServer(NetworkDisconnection info)
    {
       
        
        timeText.text = "00";
    }
    


    
    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer) return;

       // hight = Camera.main.pixelHeight;
        //width = Camera.main.pixelWidth;
        
        //timeText.rectTransform.position = (new Vector3((width-320) / 2, -40));

        if (NetworkManager.singleton.numPlayers > 1)
        {
            if(isStart)
            {
                now=DateTime.Now;
                isStart = false;
            }
            TimeSpan t = DateTime.Now.Subtract( now);
            
            iTime = timeLimited-(int)t.TotalSeconds;

            if (iTime<0)
            {
                NetworkManager.Shutdown();
                //NetworkManager.singleton.StopHost();
                isStart = true;
            }

        }

	}
    private void OnGUI()
    {
        
        //hud.offsetX =(int) ( -100)/2 ;

        string s = iTime.ToString("D2");
            timeText.text = s;

    }
}
