﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    //private SphereCollider p_pickup;
    private Rigidbody rb;
    public string target_name;
    [SerializeField]
    private Transform target;
	[SerializeField] private Collider trigger;
    public float turn_strength;
    bool move;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //p_pickup = GetComponent<SphereCollider>();
        target = GameObject.Find(target_name).transform;
	}

    void FixedUpdate() {
        if(move) {
			rb.velocity = new Vector3(rb.transform.forward.x, rb.velocity.y, rb.transform.forward.z);
			//Debug.Log (rb.velocity);
        }
		float distX = this.transform.position.x - target.position.x;
		float distZ = this.transform.position.z - target.position.z;


		if ((distX > 10 || distX < -10) && (distZ > 10 || distZ < -10)) {
			rb.isKinematic = true;
			trigger.enabled = false;
		} else {
			//rb.isKinematic = false;
			trigger.enabled = true;
		}
    }

   // void OnBecameVisible()
   // {
       // Debug.Log("Im visible");
       // rb.isKinematic = false;
       // trigger.enabled = true;
 //   }

  //  void OnBecameInvisible()
  //  {
     //   Debug.Log("NOT VISIBLE");
     //   rb.isKinematic = true;
      //  trigger.enabled = false;

   // }

    // On Trigger Enter is called Upon Entering a Trigger Area.
    void OnTriggerStay(Collider other) {
		if(other.tag == "player" && other.GetComponent<PlayerController>().HasCapacity()) {
            Vector3 targetRotation = new Vector3 (target.position.x - this.transform.position.x, 0.0f, target.position.z - this.transform.position.z);
            //Debug.Log("target: " + targetRotation.ToString());
            float str = Mathf.Min(turn_strength * Time.deltaTime, 1);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetRotation, str, 0.0F);
            //Debug.Log("newDir: " + newDir.ToString());
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            move = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "player")
        move = false;
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "player") {
            //Debug.Log("We've found the boat.");
			other.gameObject.GetComponent<PlayerController>().AddPerson(gameObject);
			this.GetComponent<Rigidbody> ().isKinematic = true;
			this.GetComponent<SphereCollider>().enabled = false;
			this.GetComponent<CapsuleCollider>().enabled = false;
			this.enabled = false;
        }
    }

}
