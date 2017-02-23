﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentalPlayerController : MonoBehaviour {
    
    public float maxSpeed = 10;
    public float accel = 150;
    public float drag = 10;
    private Rigidbody rb;
    private Vector3 heading;
	public Text fuelUI;
    
	[SerializeField]
    private float fuelUsage = 1.0f;
    [SerializeField]
    private float fuel = 100.0f;

	[SerializeField]
	private int numPeople;
	[SerializeField]
	private int peopleCapacity;
	private List<GameObject> passengers;


    // Use this for initialization
    void Start () {
		passengers = new List<GameObject> ();
        this.rb = GetComponent<Rigidbody>();
		fuelUI.text = "fuel: " + fuel;
	}

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        heading = new Vector3(x, 0.0f, z);
        transform.LookAt(this.transform.position + heading);
		fuelUI.text = "fuel: " + fuel;
    }

    void FixedUpdate() {
        rb.AddForce(-(rb.velocity * drag));

        if (fuel > 0.0f) {
            rb.AddForce(heading * accel);

            //check for max speeds X.
            if (rb.velocity.x > maxSpeed) {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            } else if (rb.velocity.x < -maxSpeed) {
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
            }

            //check for max speeds Z.
            if (rb.velocity.z > maxSpeed) {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
            } else if (rb.velocity.z < -maxSpeed) {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
            }

            fuel -= (heading).magnitude * fuelUsage;
        }
    }

    public void AddFuel(float fuel) {
        this.fuel += fuel;
    }

	public void AddPerson(GameObject person){
		numPeople++;
		passengers.Add (person);
		person.transform.SetParent (this.transform);
	}

	public void RemovePerson(){
		numPeople--;
	}

	public bool HasCapacity(){
		return (peopleCapacity - numPeople) > 0;
	}

}
