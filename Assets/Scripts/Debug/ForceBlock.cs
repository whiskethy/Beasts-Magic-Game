using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlock : MonoBehaviour {
    
    //data accessible to the Inspector
    [SerializeField] private bool canBlock = false;

    private PlayerAnimation anim;

    // Use this for initialization
    void Start () {

        anim = GetComponent<PlayerAnimation>();
        Debug.Assert(anim != null);

    }
	
	// Update is called once per frame
	void Update () {

        if(canBlock)
        {
            anim.blocking();
        }
		
	}
}
