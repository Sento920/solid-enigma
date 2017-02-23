using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRingScript : MonoBehaviour {

    /*
    *   Question: How do we want to throw this thing?
    *
    */


    private Rigidbody rb;
    private string target_name;
    private Transform target;
    private GameObject passenger;

	// Use this for initialization
	void Start () {
        target_name = "PlayerBoat";
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find(target_name).transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other) {
        //We'll make the other object a passenger.
        if(other.transform.tag == "civilian") {
            // Pull them along with us.

        }
    }

}
