using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
		
    }

    void OnTriggerStay(Collider other) {
        if(other.attachedRigidbody) {
			float forceApplied = Mathf.Max(-((other.transform.position.y - this.gameObject.transform.position.y) / 5.0f), 0.0f);
			float bouyancy = other.attachedRigidbody.mass;
			other.attachedRigidbody.AddForce(Vector3.up * (50000 * forceApplied * forceApplied));

        }
    }

    void OnTriggerExit(Collider other) {

    }
}
