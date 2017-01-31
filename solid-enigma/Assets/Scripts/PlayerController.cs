using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public int oomph = 10;
	[SerializeField]
	private int foo = 10;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical")) * oomph;

		rb.velocity = newVelocity;

		
	}

	void FixedUpdate(){
		
	}
}
