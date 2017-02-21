using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    enum GameState { Playing, Shop, Paused };   // what other states do we need?  loading?  starting?  game over?

    private float timeLeft;
    private GameState state = GameState.Paused;
    

    [SerializeField] private float timeInMinutes = 5;
    [SerializeField] private GameObject sun;
    [SerializeField] private CanvasGroup shopCanvas;
	[SerializeField] private CanvasGroup gameCanvas;
	[SerializeField] private Text timerText;

    // Use this for initialization
    void Start () {
        ResetTimer();
        StartTimer();
		shopCanvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (state == GameState.Playing) {
			gameCanvas.gameObject.SetActive(true);
            timeLeft -= Time.deltaTime;

            float sunAngle = (timeLeft / (timeInMinutes * 60));
            sunAngle *= 180;

            sun.transform.rotation = Quaternion.Euler(sunAngle, -30.0f, 0.0f);

            //Debug.Log(getTime());
			timerText.text = getTime();

            if (timeLeft <= 0.0f) {
                PauseTimer();
                ResetTimer();

				state = GameState.Shop;

                // TODO: setup shop (hah), and get ready for the next round
            }
        } else if (state == GameState.Shop) {
			shopCanvas.gameObject.SetActive(true);
			gameCanvas.gameObject.SetActive(false);
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
		if (timeLeft <= 0.0f) {
			return "0:00";
		}
        int minutes = (int)Mathf.Floor(timeLeft / 60);
        int seconds = (int)timeLeft - (60 * minutes);
        if (seconds >= 10)
            return minutes + ":" + seconds;
        else
            return minutes + ":0" + seconds;
    }
}
