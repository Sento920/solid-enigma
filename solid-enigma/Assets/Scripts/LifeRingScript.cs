using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRingScript : MonoBehaviour {

    /*
    *   Question: How do we want to throw this thing?
    *
    */


    private Rigidbody rb;
    [SerializeField]
    private Transform Anchor;
    private SpringJoint joint;
    [SerializeField]
    private float delay;
    private float time;
    private bool hasPerson;
    //private GameObject passenger;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //Has person is for if we decide to implement carrying people behind the boat.
        //Note: That Feature will be a pain to do correctly thanks to the difficult/expensive part of making psudo-ropes. 
        hasPerson = false;
    
        Anchor = GameObject.Find("PlayerBoat").transform;
        
    }

    void OnCollisionEnter(Collision other) {
        //We'll make the other object a passenger.
        if(other.transform.tag == "civilian") {
            // touch a person, put them in the boat.
            Anchor.GetComponent<PlayerController>().AddPerson(other.gameObject);
            Destroy(gameObject);
        }else if(other.transform.tag == "player") {
            if(hasPerson) {
                Debug.Log("This should never print.");
            } else {
                // We've collided with our empty ring, pick it up.
                Anchor.GetComponent<PlayerController>().AddRing();
            }
        } 
           
    }

}
