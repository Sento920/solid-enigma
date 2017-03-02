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
                Debug.Log("Evacuated a person!");
            }
        }
    }
}
