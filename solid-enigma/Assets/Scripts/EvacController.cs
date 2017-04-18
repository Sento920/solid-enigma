using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacController : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            PlayerController p = other.GetComponent<PlayerController>();
            while (p.GetNumPassengers() > 0) {
                p.RemovePerson();
                Debug.Log("Person evacuated!");
                p.AddMoney(5);
            }
        }
    }

   void OnTriggerStay(Collider other)
    {
    }

    void OnCollisionEnter(Collision zone)
       {
           if (zone.transform.tag == "player")
           {
               zone.gameObject.GetComponent<PlayerController>().AddPerson(gameObject);
               this.GetComponent<Rigidbody>().isKinematic = true;
               this.GetComponent<SphereCollider>().enabled = false;
               this.GetComponent<CapsuleCollider>().enabled = false;
               this.enabled = false;
           }
       } 
}
