using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour {

    enum GameState { Playing, Shop, Paused, Lose };   // what other states do we need?  loading?  starting?  game over?

    private float timeLeft;
    private GameState state = GameState.Paused;
	[SerializeField]
	private GameObject playerRef;
    [SerializeField]
    private GameObject spawnPosition;
    [SerializeField]
    private GameObject clockRef;
	[SerializeField]
	private int peepCount;
	[SerializeField]
	private int peepQuota;
	[SerializeField]
	private Text peepUI;

    [SerializeField]
    private Text rescueText;

    [SerializeField] private float timeInMinutes = 5;
    [SerializeField] private GameObject sun;
    [SerializeField] private CanvasGroup shopCanvas;
	[SerializeField] private CanvasGroup gameCanvas;
    [SerializeField] private CanvasGroup pauseCanvas;
    [SerializeField] private Canvas loseCanvas;
    [SerializeField]
    private LevelGenerator levelGenerator;
    //[SerializeField] private Text timerText;

    // Use this for initialization
    void Start () {
        ResetTimer();
        StartTimer();
		peepCount = 0;
		shopCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
        rescueText.enabled = true;
        clockRef.GetComponent<ClockScript>().SetMaxValue(timeLeft);
        clockRef.GetComponent<ClockScript>().SetMinValue(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (state == GameState.Playing) {
			gameCanvas.gameObject.SetActive(true);
			peepUI.text = peepCount + "/" + peepQuota;
            timeLeft -= Time.deltaTime;
			playerRef.GetComponent<PlayerController>().setActiveTime(true);
            float sunAngle = (timeLeft / (timeInMinutes * 60));
            sunAngle *= 180;

            sun.transform.rotation = Quaternion.Euler(sunAngle, -30.0f, 0.0f);

            //Debug.Log(getTime());
			//timerText.text = getTime();
            clockRef.GetComponent<ClockScript>().SetTargetValue(timeLeft);
            if ((Input.GetKeyDown(KeyCode.Escape) == true))
            {   
                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                state = GameState.Paused;
            } 

            if (timeLeft <= 0.0f) {
				PauseTimer();
				ResetTimer();

				if (peepCount < peepQuota) {
					//Debug.Log ("YOU MADE CHRIS SAD, AND YOU SHOULD BE ASHAMED.\nYA FIRED!");
					loseCanvas.gameObject.SetActive (true);
					state = GameState.Lose;
				} else {
					//loseCanvas.gameObject.SetActive(true);
					state = GameState.Shop;
				}
                // TODO: setup shop (hah), and get ready for the next round
            }


            rescueText.text = "Rescue " + peepQuota + " People";
            if (timeLeft < (timeInMinutes  * 60) - 3)
            {
                rescueText.enabled = false;
            }


        } else if (state == GameState.Shop) {
			shopCanvas.gameObject.SetActive(true);
			//gameCanvas.gameObject.SetActive(false);
            // TODO: shop related things, if they apply...
			playerRef.GetComponent<PlayerController>().setActiveTime(false);
            playerRef.transform.position = spawnPosition.transform.position;
        } else if (state == GameState.Paused) {
            // look for unpause...
            playerRef.GetComponent<PlayerController>().setActiveTime(false);
            if ((Input.GetKeyDown(KeyCode.Escape) == true))
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                state = GameState.Playing;
            }

        }
	}

    void ResetTimer () {
        timeLeft = 60.0f * timeInMinutes;
        clockRef.GetComponent<ClockScript>().SetMaxValue(timeLeft);
        clockRef.GetComponent<ClockScript>().SetMinValue(0);
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

	public void NewDay(){
        levelGenerator.GenerateLevel();
		shopCanvas.gameObject.SetActive(false);
		loseCanvas.gameObject.SetActive (false);
		gameCanvas.gameObject.SetActive(true);
        rescueText.enabled = true;
        shopCanvas.GetComponent<ShopButtonController>().enableShopButtons();
        playerRef.transform.position = spawnPosition.transform.position;
		AddQuota ();
        peepCount = 0;
		ResetTimer();
		StartTimer();
	}

    public void Resume()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        state = GameState.Playing;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        state = GameState.Playing;
        Time.timeScale = 1;
    }

	public void AddPoint(){
		peepCount++;
	}

    public void ExitGame()
    {
        Application.Quit();
    }

	public void AddQuota(){
		peepQuota += 2;
	}

	public int GetQuota(){
		return peepQuota;
	}
}
