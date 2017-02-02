using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	[SerializeField]
	private int p_mov_const = 10;
        private Vector3 p_heading;

	// Use this for initialization
	void Start () {
                p_heading = new Vector3();
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
        float logx = Input.GetAxis("Horizontal");
        float logz = Input.GetAxis("Vertical");

		//Input Checking
		if (logx < 0.0f && logz < 0.0f) {
			p_heading = new Vector3 ( -1 * Mathf.Log10 ((logx * -1) + 1), 0.0f, -1 * Mathf.Log10 ((logz * -1) + 1));
		}
		else if(logx < 0.0f){
			p_heading = new Vector3 ( -1 * Mathf.Log10 ((logx * -1) + 1), 0.0f, Mathf.Log10 (logz + 1));
		}else if(logz < 0.0f){
			p_heading = new Vector3( Mathf.Log10(logx + 1), 0.0f, -1 * Mathf.Log10((logz * -1) + 1));
		}else{
			p_heading = new Vector3( Mathf.Log10(logx + 1), 0.0f, Mathf.Log10(logz + 1));
		}
		
	}

	void FixedUpdate(){
		rb.AddForce(p_heading * p_mov_const);
                //rb.velocity = p_heading * p_mov_const;
	}
}
