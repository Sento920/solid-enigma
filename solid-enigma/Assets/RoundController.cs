using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {

    private float timeLeft;
    private bool timerActive = false;

    [SerializeField] private float timeInMinutes = 5;
    [SerializeField] private GameObject sun;

	// Use this for initialization
	void Start () {
        ResetTimer();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;

        float sunAngle = (timeLeft / (timeInMinutes * 60));
        sunAngle *= 180;

        sun.transform.rotation = Quaternion.Euler(sunAngle, -30.0f, 0.0f);

        Debug.Log(getTime());
	}

    void ResetTimer () {
        timeLeft = 60.0f * timeInMinutes;
    }

    void StartTimer () {
        // starts or resumes the timer
        timerActive = true;
    }

    void PauseTimer () {
        // pauses the timer
        timerActive = false;
    }

    string getTime () {
        int minutes = (int)Mathf.Floor(timeLeft / 60);
        int seconds = (int)timeLeft - (60 * minutes);
        return minutes + ":" + seconds;
    }
}
