using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float GameTime = 30.0f;
	public float TimePerTask = 12.0f;
	
	private float timer = 0.0f;
	private Rect timeRect;
	
	private int score = 0;
	
	public bool gameOver = false;

	public string[] rankings;
	public string[] descriptions;

	// Use this for initialization
	void Start () {
		timer = GameTime;
		
		timeRect = new Rect(0, 0, Screen.width/20.0f, Screen.height/20.0f);
	}
	
	public void AddTime(float extraTime) {
		timer += extraTime;
	}
	
	public float GetTime() {
		return timer;
	}
	
	public float GetScore() {
		return score;
	}
	
	public string GetRank() {
		return rankings[score/10];
	}
	
	public string GetDescription() {
		return descriptions[score/10];
	}
	
	public void AddScore(int amount) {
		score += amount;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimers();
		
		GetRank();
	}
	
	void UpdateTimers() {
		if(!gameOver) {
			timer -= Time.deltaTime;
			if(timer <= 0.0f) GameOver();
		} else {
			if(Input.GetButtonDown ("Fire1")) {
				Application.LoadLevel (0);
			}	
		}
		
		if(Input.GetKeyDown (KeyCode.Escape)) Application.Quit ();
	}
	
	void GameOver() {
		gameOver = true;
		Debug.Log ("Game Over!");
	}
	
	string FormatTime(float time) {
		int secs = (int)(time % 60.0f);
		int mins = (int)(time / 60.0f);
		
		return string.Format("{0:00}:{1:00}", mins, secs);
	}
	
	void OnGUI() {
		string time = FormatTime(timer);
		GUI.Label (timeRect, time);
	}
}
