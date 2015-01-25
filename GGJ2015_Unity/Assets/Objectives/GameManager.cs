using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float GameTime = 30.0f;
	public float TimePerTask = 12.0f;
	
	private float timer = 0.0f;
	private Rect timeRect;

	// Use this for initialization
	void Start () {
		timer = GameTime;
		
		timeRect = new Rect(0, 0, Screen.width/20.0f, Screen.height/20.0f);
	}
	
	public void AddTime(float extraTime) {
		timer += extraTime;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimers();
	}
	
	void UpdateTimers() {
		timer -= Time.deltaTime;
		if(timer <= 0.0f) GameOver();
	}
	
	void GameOver() {
		Debug.Log ("Game Over!");
		Application.LoadLevel (0); 
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
