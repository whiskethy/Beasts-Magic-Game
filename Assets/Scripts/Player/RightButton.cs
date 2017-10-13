using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


public class RightButton : MonoBehaviour {
	private Image rightButtonImg;

	// Use this for initialization
	void Start() {
		rightButtonImg = GetComponent<Image>();
		Button btn = rightButtonImg.GetComponent<Button>();
		if (btn == null) {
			Debug.Log ("Button is null for reasons unkown:" +  rightButtonImg.ToString());
		} else {
			btn.onClick.AddListener(TaskOnClick);
		}
	}

	void TaskOnClick(){
		Debug.Log("You have clicked the right button!");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
