using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    public PlayerData player1Data;
    public PlayerData player2Data;

    private PlayerAnimation anim;
    private bool find;

    public Text p1healthText;
    [SerializeField] private string player1HealthText;

    public Text p2healthText;
    [SerializeField] private string player2HealthText;

    public void Start()
    {
        player1 = GameObject.FindWithTag("Player1");
        Debug.Assert(player1 != null);
        player1Data = player1.GetComponent<PlayerData>();
        Debug.Assert(player1Data != null);

        player2 = GameObject.FindWithTag("Player2");
        Debug.Assert(player2 != null);
        player2Data = player2.GetComponent<PlayerData>();
        Debug.Assert(player2Data != null);

        //healthText = GameObject.Find(playerHealthText).GetComponent<Text>();
        Debug.Assert(p1healthText != null);
        Debug.Assert(p2healthText != null);

        player1Data.currentHealth = player1Data.characterHealthPool;
        player2Data.currentHealth = player2Data.characterHealthPool;
    }

    public void Update()
    {
        p1healthText.text = "Health: " + player1Data.currentHealth.ToString();
        p2healthText.text = "Health: " + player1Data.currentHealth.ToString();

        //healthText = playerHealthText;
        if (player1Data.currentHealth <= 0)
        {
            player1.GetComponent<PlayerAnimation>().death();
        }
        else if(player2Data.currentHealth <= 0)
        {
            player2.GetComponent<PlayerAnimation>().death();
        }
    }


    public void takeDamage(GameObject player, int damage)
    {
        player.GetComponent<PlayerData>().currentHealth -= damage;
    }
}
