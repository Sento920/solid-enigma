using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    void OnTriggerEnter(Collider other) {

    }

    void OnTriggerStay(Collider other) {
        if(other.tag == "player" && other.attachedRigidbody) {
            other.attachedRigidbody.AddForce(Vector3.up * 110);
        }
    }

    void OnTriggerExit(Collider other) {

    }
}
