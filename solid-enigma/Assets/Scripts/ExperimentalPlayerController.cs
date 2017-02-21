using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalPlayerController : MonoBehaviour {
    
    public float maxSpeed;
    public float accel;
    private Rigidbody rb;
    private Vector3 heading;


	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        heading = new Vector3(x, 0.0f, z);
        transform.LookAt(this.transform.position + heading);
        
    }

    void FixedUpdate() {
        if(heading.x != 0 || heading.z != 0) {
            rb.AddForce(heading * accel);
        }
        //check for max speeds X.
        if(rb.velocity.x > maxSpeed) {
            rb.velocity = new Vector3(maxSpeed, 0.0f, rb.velocity.z);
        } else if(rb.velocity.x < -maxSpeed) {
            rb.velocity = new Vector3(-maxSpeed, 0.0f, rb.velocity.z);
        }
        //check for max speeds Z.
        if(rb.velocity.z > maxSpeed) {
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, maxSpeed);
        }else if(rb.velocity.z < -maxSpeed) {
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, -maxSpeed);
        }
        
        

    }
}
