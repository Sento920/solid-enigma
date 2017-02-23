using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField]
    private int movConst = 10;
    private Vector3 heading;

    [SerializeField] private float fuelUsage = 1.0f;
    private float fuel = 100.0f;

	private Vector3 velocity;

    void AddFuel(float fuel) {
        fuel += fuel;
    }

	// Use this for initialization
	void Start () {
        heading = new Vector3();
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

		heading = new Vector3 (xAxis, 0.0f, zAxis);

		transform.LookAt (this.transform.position + heading);
	}

	void FixedUpdate(){
		//rb.AddForce(heading * movConst);
		float logx = (heading.x * movConst);
        float logz = (heading.z * movConst);
        velocity = new Vector3(logx,0.0f,logz);

        /*Input Checking
		if (logx < 0.0f && logz < 0.0f) {
			velocity = new Vector3 ( -1 * Mathf.Log10 ((logx * -1) + 1), 0.0f, -1 * Mathf.Log10 ((logz * -1) + 1));
		}
		else if(logx < 0.0f){
			velocity = new Vector3 ( -1 * Mathf.Log10 ((logx * -1) + 1), 0.0f, Mathf.Log10 (logz + 1));
		}else if(logz < 0.0f){
			velocity = new Vector3( Mathf.Log10(logx + 1), 0.0f, -1 * Mathf.Log10((logz * -1) + 1));
		}else{
			velocity = new Vector3( Mathf.Log10(logx + 1), 0.0f, Mathf.Log10(logz + 1));
		}*/

        fuel -= velocity.magnitude * fuelUsage;
			
        rb.AddForce(velocity);
	}
}
