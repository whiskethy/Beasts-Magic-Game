using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : State {
	private int numberOfStates;
	private State[] states;
	private int currentState = 0;

	private static int IDLE_STATE = 0;
	private static int ATTACK_STATE = 1;
	private static int DEFENDING_STATE = 2;

	// Use this for initialization
	void Start () {
		int numberOfStates = 3;
		states = new State[numberOfStates];
		states[0] =  new IdleState ();
		states[1] =  new AttackingState ();
		states[2] =  new DefendingState ();

		states [0].On();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void on(){
		states [currentState].On ();
	}

	public void off(){
		states [currentState].Off ();
	}

	public void ack() {
		states [currentState].Ack ();
	}
}
