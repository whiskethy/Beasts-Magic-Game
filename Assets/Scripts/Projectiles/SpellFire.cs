using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFire : MonoBehaviour {

    [SerializeField] private float projectileSpeed = 10.0f;

    private Rigidbody bulletRigidBody;

	// Use this for initialization
	void Start () {

        bulletRigidBody = gameObject.GetComponent<Rigidbody>();
        Debug.Assert(bulletRigidBody != null);

	}
	
	// Update is called once per frame
	void Update () {

        bulletRigidBody.velocity = transform.forward * projectileSpeed ;
	}
}
