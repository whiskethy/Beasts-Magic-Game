using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

    Text healthText;

    [SerializeField] private string playerHealthText;

    public float movementSpeed;
    public int currentHealth;
    public int playerHealhPool;

    public int attackSpeed;
    public int strength;  //physical attacks
    public int agility;   //blocking
    public int wisdom;    //ranged attacks


	public void Start()
    {
		movementSpeed = 3.0f;
		currentHealth = 100;
		playerHealhPool = 1;

        healthText = GameObject.Find(playerHealthText).GetComponent<Text>();
        Debug.Assert(healthText != null);

    }

	public void Update()
    {
		healthText.text = "Health: "+ currentHealth.ToString();

        if(currentHealth <= 0)
        {
            currentHealth = 100;
        }
	}
}
