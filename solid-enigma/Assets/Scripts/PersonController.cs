using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    //private SphereCollider p_pickup;
    private Rigidbody rb;
    public string target_name;
    [SerializeField]
    private Transform target;
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
            rb.velocity = rb.transform.forward;
        }

    }

    // On Trigger Enter is called Upon Entering a Trigger Area.
    void OnTriggerStay(Collider other) {
        if(other.tag == "player") {
            Debug.Log("Player has entered the pick up area");
            //Debug.Log( "Boat: " + target.position.ToString());
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
            Debug.Log("We've found the boat.");
            Destroy(this.gameObject);
        }
    }

}
