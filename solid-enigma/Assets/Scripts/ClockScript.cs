using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClockScript : MonoBehaviour {



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
    void Start() {
        //Grabs the Sprite, converts the size to Pixels and then uses the pixels + Sprite's pivot to set the correct pivot for the RectTransform.
        target = 0;
        angle = 0;
    }

    // Update is called once per frame
    void Update() {
        angle = Mathf.Clamp(target, minVal, maxVal);
        angle = ((target / maxVal)) * 360;
        //Debug.Log("MAX: " + maxVal + " MIN: " + minVal + " TARGET: " + target + " Angle: " + angle);
        //transform target to Angle~!

        Indicator.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //Debug.Log("Rotation: " + Indicator.transform.rotation);

    }

    public void SetTargetValue(float target) {
        //Debug.Log("TARGET SET TO: " + target);
        this.target = target;
    }

    public void SetMaxValue(float max) {
        this.maxVal = max;
    }

    public void SetMinValue(float min) {
        this.minVal = min;
    }
}
