using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour {

    [SerializeField] private GameObject playerObj;

    private PlayerAttack pAttack;

	// Use this for initialization
	void Start () {

        pAttack = playerObj.GetComponent<PlayerAttack>();
        Debug.Assert(pAttack != null);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player2" && (pAttack.getAttack1 || pAttack.getAttack2))
        {
            Debug.Log("Collided with: " +other.gameObject.name);
        }
    }
}
