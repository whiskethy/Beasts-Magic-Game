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

	public void Start()
    {
		movementSpeed = 3.0f;
		currentHealth = 100;
		playerHealhPool = 1;
		deathRate = 1000;

        healthText = GameObject.Find("Text").GetComponent<Text>();
    }

	public void Update()
    {
		healthText.text = "Health: "+ currentHealth.ToString();
	}
}
