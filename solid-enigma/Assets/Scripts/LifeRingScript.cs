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
    [SerializeField]
    private Transform Anchor;
    private SpringJoint joint;
    [SerializeField]
    private float delay;
    private float time;
    //private GameObject passenger;

	// Use this for initialization
	void Start () {
        target_name = "PlayerBoat";
        rb = GetComponent<Rigidbody>();
        /*
        joint = GetComponent<SpringJoint>();
        time = Time.time;
        */
        Anchor = GameObject.Find("PlayerBoat").transform;
        
    }
	/*
	// Update is called once per frame
	void Update () {
        if( Time.time > (time + delay) && Anchor.tag == "player") {
            this.transform.position = new Vector3(transform.position.x,0.0f,transform.position.z);
            joint.connectedBody = Anchor.GetComponent<Rigidbody>();
        }
    }
    
    */

    void OnCollisionEnter(Collision other) {
        //We'll make the other object a passenger.
        if(other.transform.tag == "civilian") {
            // touch a person, put them in the boat.
            Anchor.GetComponent<PlayerController>().AddPerson(other.gameObject);
            Destroy(gameObject);
        }
        ///if(other.transform.tag == "player" && other.gameObject.GetComponent<PlayerController>().HasCapacity()) 
           
    }

}
