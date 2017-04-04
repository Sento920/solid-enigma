using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GaugeScript : MonoBehaviour {

    //Doing this following Chris's UI stuff from 3D. 
    //http://www.twodee.org/blog/?p=13668

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
        //Grabs the Sprite, converts the size to Pixels and then uses the pixels + Sprite's pivot to set the correct pivot for the RectTransform.
        Vector2 size = GetComponent<RectTransform>().sizeDelta;
        size *= GetComponent<Image>().pixelsPerUnit;
        Vector2 pixelPivot = GetComponent<Image>().sprite.pivot;
        Vector2 percentPivot = new Vector2(pixelPivot.x / size.x, pixelPivot.y / size.y);
        GetComponent<RectTransform>().pivot = percentPivot;
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

    public void SetMaxValue(float max) {
        this.maxVal = max;
    }

    public void SetMinValue(float min) {
        this.minVal = min;
    }
}
