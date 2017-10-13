using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


public class LeftButton : MonoBehaviour {
	private Image leftButtonImg;

	// Use this for initialization
	void Start() {
		leftButtonImg = GetComponent<Image>();

		Button btn = leftButtonImg.GetComponent<Button>();
		if (btn == null) {
			Debug.Log ("Button is null for reasons unkown:" +  leftButtonImg.ToString());
		} else {
			btn.onClick.AddListener(TaskOnClick);
		}

	}

	void TaskOnClick() {
		Debug.Log("You have clicked the left button!");
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
