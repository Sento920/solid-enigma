using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    public Transform target;

    private float getAngle(Vector3 vec)
    {
        float negative = 1.0f;

        if (vec.x < 0.0f)
            negative *= -1.0f;

        return Vector3.Angle(Vector3.forward, vec.normalized) * negative;
    }
	
	// Update is called once per frame
	void Update () {
        // get desired movement vector
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 desiredHeading = new Vector3(x, 0.0f, z);

        if (desiredHeading.magnitude > 1.0f)
            desiredHeading.Normalize();

        gameObject.transform.position = target.position;
        gameObject.transform.localScale = new Vector3(desiredHeading.magnitude, desiredHeading.magnitude, desiredHeading.magnitude);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, getAngle(desiredHeading), 0.0f));
    }
}
