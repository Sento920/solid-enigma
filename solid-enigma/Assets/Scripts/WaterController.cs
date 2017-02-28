using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    [SerializeField] private float bounceDamp = 0.05f;
    [SerializeField] private float horizontalDrag = 0.10f;

    void OnTriggerEnter(Collider other) {
		
    }

    void OnTriggerStay(Collider other) {
        if(other.attachedRigidbody && !other.isTrigger) {
            float force = 1.0f - ((other.transform.position.y - transform.position.y) / 5.0f);

            Vector3 forceVector = -Physics.gravity * other.attachedRigidbody.mass * (force - other.attachedRigidbody.velocity.y * bounceDamp);
            Vector3 dragVector = -other.attachedRigidbody.velocity * horizontalDrag;
            dragVector.y = 0.0f;

            other.attachedRigidbody.AddForce(forceVector + dragVector);
        }
    }

    void OnTriggerExit(Collider other) {

    }
}
