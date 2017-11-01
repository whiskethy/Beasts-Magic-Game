using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour {

    [SerializeField] private GameObject playerObj;

    private PlayerAttack pAttack;
    private PlayerData pData;

	// Use this for initialization
	void Start () {

        pAttack = playerObj.GetComponent<PlayerAttack>();
        Debug.Assert(pAttack != null);

        pData = playerObj.GetComponent<PlayerData>();
        Debug.Assert(pData != null);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player2" && pAttack.getAttack1)
        {
            Debug.Log("Collided with: " +other.gameObject.name);
            Debug.Log("Player Attack 1: " + pAttack.getAttack1);

            other.gameObject.GetComponent<PlayerData>().currentHealth -= 10;
        }

        if (other.gameObject.tag == "Player2" && pAttack.getAttack2)
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            Debug.Log("Player Attack 2: " + pAttack.getAttack2);

            other.gameObject.GetComponent<PlayerData>().currentHealth -= 20;
        }

        if (other.gameObject.tag == "Player1" && pAttack.getAttack1)
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            Debug.Log("Player Attack 1: " + pAttack.getAttack1);

            other.gameObject.GetComponent<PlayerData>().currentHealth -= 10;
        }

        if (other.gameObject.tag == "Player1" && pAttack.getAttack2)
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            Debug.Log("Player Attack 2: " + pAttack.getAttack2);

            other.gameObject.GetComponent<PlayerData>().currentHealth -= 20;
        }
    }
}
