using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour {

    public Material[] Array1;
    public Material[] Array2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Material[] getA1() {
        return Array1;
    }

    public Material[] getA2(){
        return Array2;
    }
}
