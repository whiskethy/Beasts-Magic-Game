using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    //data accessible to the Inspector
    [SerializeField] private float attack1DisableDelay = 0.5f;
    [SerializeField] private float attack2DisableDelay = 1.5f;

    //data
    private bool attack1;
    private bool attack2;
    private bool canBlock;

    private PlayerAnimation anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<PlayerAnimation>();
        Debug.Assert(anim != null);
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
            StartCoroutine(DisableAttack1());
        }

        if(Input.GetMouseButtonDown(1) && !attack1)
        {
            attack2 = true;
            Debug.Log("Attack 2 Start");
            StartCoroutine(DisableAttack2());
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

    private IEnumerator DisableAttack1()
    {
        anim.attackOne(attack1);
        yield return new WaitForSeconds(this.attack1DisableDelay);
        Debug.Log("Attack 1 Stop");
        this.attack1 = false;
        anim.attackOne(attack1);
    }

    private IEnumerator DisableAttack2()
    {
        anim.attackTwo(attack2);
        yield return new WaitForSeconds(this.attack2DisableDelay);
        this.attack2 = false;
        Debug.Log("Attack 2 Stop");
        anim.attackTwo(attack2);
    }

    public bool getAttack1
    {
        get { return attack1; }
    }

    public bool getAttack2
    {
        get { return attack2; }
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
