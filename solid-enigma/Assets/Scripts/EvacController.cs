using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacController : MonoBehaviour {

    [SerializeField]
    private RoundController rc;
	[SerializeField]
	private GameObject[] evacSlots;
	int numPeople = 0;

    // Use this for initialization
    void Start () {
        rc = GameObject.FindObjectOfType<RoundController>();
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
                GameObject person = p.RemovePerson();
				if (person){
					Debug.Log ("Person evacuated!");
					person.transform.SetParent (this.transform);
					person.transform.position = evacSlots [numPeople].transform.position;
					numPeople++;
					p.AddMoney (5);
                    rc.AddPoint();
				} else {
					Debug.Log ("NULL RETURNED");
				}
            }
        }
    }

   void OnTriggerStay(Collider other)
    {
    }

    /*void OnCollisionEnter(Collision zone)
       {
           if (zone.transform.tag == "player")
           {
               zone.gameObject.GetComponent<PlayerController>().AddPerson(gameObject);
               this.GetComponent<Rigidbody>().isKinematic = true;
               this.GetComponent<SphereCollider>().enabled = false;
               this.GetComponent<CapsuleCollider>().enabled = false;
               this.enabled = false;
           }
       } */
}
