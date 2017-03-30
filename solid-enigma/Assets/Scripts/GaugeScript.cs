using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeScript : MonoBehaviour {

    //Doing this following Chris's UI stuff from 3D. 
    //http://www.twodee.org/blog/?p=13668

    [SerializeField]
    private float target;
    private float angle;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float minVal;
    [SerializeField]
    private float minAngle;
    [SerializeField]
    private float maxAngle;
    [SerializeField]
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        angle = maxAngle;
        

	}
	
	// Update is called once per frame
	void Update () {
	}
}
