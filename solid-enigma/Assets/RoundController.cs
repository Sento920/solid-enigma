using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {

    enum GameState { Playing, Shop, Paused };   // what other states do we need?  loading?  starting?  game over?

    private float timeLeft;
    private GameState state = GameState.Paused;

    [SerializeField] private float timeInMinutes = 5;
    [SerializeField] private GameObject sun;

	// Use this for initialization
	void Start () {
        ResetTimer();
        StartTimer();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == GameState.Playing) {
            timeLeft -= Time.deltaTime;

            float sunAngle = (timeLeft / (timeInMinutes * 60));
            sunAngle *= 180;

            sun.transform.rotation = Quaternion.Euler(sunAngle, -30.0f, 0.0f);

            Debug.Log(getTime());

            if (timeLeft < 0.0f)
            {
                state = GameState.Shop;

                PauseTimer();
                ResetTimer();

                // TODO: setup shop (hah), and get ready for the next round
            }
        } else if (state == GameState.Shop) {
            // TODO: shop related things, if they apply...
        } else if (state == GameState.Paused) {
            // look for unpause...
        }
	}

    void ResetTimer () {
        timeLeft = 60.0f * timeInMinutes;
    }

    void StartTimer () {
        // starts or resumes the timer
        state = GameState.Playing;
    }

    void PauseTimer () {
        // pauses the timer
        state = GameState.Paused;
    }

    string getTime () {
        // i'm not sure about having a digital clock, it seems too precise.  maybe we should switch to an analog clock?
        int minutes = (int)Mathf.Floor(timeLeft / 60);
        int seconds = (int)timeLeft - (60 * minutes);
        if (seconds >= 10)
            return minutes + ":" + seconds;
        else
            return minutes + ":0" + seconds;
    }
}
