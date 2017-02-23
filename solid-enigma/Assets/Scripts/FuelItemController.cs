using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItemController : MonoBehaviour {

    [SerializeField]
    private float containedFuel = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(0.0f, 0.5f, 0.0f));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("Player Collected Fuel");
            other.GetComponent<ExperimentalPlayerController>().AddFuel(containedFuel);
            Destroy(this.gameObject);
        }
    }
}
