using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour {

    [SerializeField] private GameObject playerObj;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private bool offlineMode;

    private PlayerAttack pAttack;
    private PlayerAttackOffline pAttackO;
    private PlayerData pData;

	// Use this for initialization
	void Start () {

        healthManager = FindObjectOfType<HealthManager>();
        Debug.Assert(healthManager != null);

        if (!offlineMode)
        {
            pAttack = playerObj.GetComponent<PlayerAttack>();
            Debug.Assert(pAttack != null);
        }
        else
        {
            pAttackO = playerObj.GetComponent<PlayerAttackOffline>();
            Debug.Assert(pAttack != null);
        }

        pData = playerObj.GetComponent<PlayerData>();
        Debug.Assert(pData != null);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (!offlineMode)
        {
            if (other.gameObject.tag == "Player2" && pAttack.getAttack1)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 1: " + pAttack.getAttack1);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 10);
            }

            if (other.gameObject.tag == "Player2" && pAttack.getAttack2)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 2: " + pAttack.getAttack2);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 20);
            }

            if (other.gameObject.tag == "Player1" && pAttack.getAttack1)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 1: " + pAttack.getAttack1);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 10);
            }

            if (other.gameObject.tag == "Player1" && pAttack.getAttack2)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 2: " + pAttack.getAttack2);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 20);
            }
        }
        else
        {
            if (other.gameObject.tag == "Player2" && pAttackO.getAttack1)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 1: " + pAttackO.getAttack1);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 10);
            }

            if (other.gameObject.tag == "Player2" && pAttackO.getAttack2)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 2: " + pAttackO.getAttack2);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 20);
            }

            if (other.gameObject.tag == "Player1" && pAttackO.getAttack1)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 1: " + pAttackO.getAttack1);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 10);
            }

            if (other.gameObject.tag == "Player1" && pAttackO.getAttack2)
            {
                Debug.Log("Collided with: " + other.gameObject.name);
                Debug.Log("Player Attack 2: " + pAttackO.getAttack2);

                other.gameObject.GetComponent<PlayerAnimation>().lightHit();
                healthManager.takeDamage(other.gameObject, 20);
            }
        }
    }
}
