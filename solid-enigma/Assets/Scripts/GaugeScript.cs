using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GaugeScript : MonoBehaviour {

    //Doing this following Chris's UI stuff from 3D. 
    //http://www.twodee.org/blog/?p=13668

	[SerializeField]
	private Image background;
	[SerializeField]
	private Image Indicator;
	[SerializeField]
    private float target;
    private float angle;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float minVal;
	// Use this for initialization
	void Start () {
        target = 0;
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Clamp(minVal,maxVal,target);
		Indicator.transform.rotation = Quaternion.Euler (new Vector3(0f,0f,angle));

	}

	public void SetTargetValue(float target){
		this.target = target;
	}

}
