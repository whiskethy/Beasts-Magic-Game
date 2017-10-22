using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    //data
    private bool attack1;
    private bool attack2;
    private bool canBlock;

    private PlayerAnimation anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<PlayerAnimation>();
        attack1 = false;
        attack2 = false;
        canBlock = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0) && !attack2)
        {
            Debug.Log("Attack 1 Start!");
            attack1 = true;
            anim.attackOne(attack1);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Attack 1 Stop");
            attack1 = false;
            anim.attackOne(attack1);
        }

        if(Input.GetMouseButtonDown(1) && !attack1)
        {
            attack2 = true;
            Debug.Log("Attack 2 Start");
        }

        if (Input.GetMouseButtonUp(1))
        {
            attack2 = false;
            Debug.Log("Attack 2 Stop");
        }

        if(attack1 && attack2)
        {
            canBlock = true;
            Debug.Log("Blocking Attack");
        }
        else
        {
            canBlock = false;
        }
    }

    public void Attack1()
    {
        attack1 = true;
    }

    public void Attack2()
    {
        attack2 = true;
    }

    public void Block()
    {
        canBlock = true;
    }
}
