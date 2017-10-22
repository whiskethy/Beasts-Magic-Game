using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

    Text healthText;
    public float movementSpeed;
    public int currentHealth;
    public int playerHealhPool;

    public int attackSpeed;
    public int strength;  //physical attacks
    public int agility;   //blocking
    public int wisdom;    //ranged attacks

	
	private int deathRate;

	public void start(){
		movementSpeed = 1.0f;
		currentHealth = 82;
		playerHealhPool = 1;
		deathRate = 1000;
	}

	public void Update(){
		if (deathRate == 0) {
			currentHealth -= 1;
			deathRate = 1000;
		}
		deathRate -= 1;
	
		healthText = GameObject.Find("Text").GetComponent <Text> ();
		healthText.text = "Health: "+ currentHealth.ToString();
	}
}
