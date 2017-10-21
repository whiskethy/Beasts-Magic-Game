using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : StateMachineBehaviour {
	protected bool enabled;
	// Use this for initialization
	void Start () {
		bool enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void On () 
	{
		enabled = true;
	}
	public void Off ()
	{
		enabled = false;
	}
	public void Ack (){
		Debug.Log ("ACK");
	}
}
