using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonRandomizer : MonoBehaviour {
    GameObject MaterialHolder;
    private Material head;
    private Material body;
    
	// Use this for initialization
	void Start () {
        MaterialHolder = GameObject.FindWithTag("Material");
        Material[] bodyColors = MaterialHolder.GetComponent<MaterialHolder>().getA1();
        Material[] headColors = MaterialHolder.GetComponent<MaterialHolder>().getA2();
        GetComponent<Renderer>().material = bodyColors[Random.Range(0,bodyColors.Length)];
        GetComponentInChildren<Renderer>().material = headColors[Random.Range(0, headColors.Length)];
	}

}
