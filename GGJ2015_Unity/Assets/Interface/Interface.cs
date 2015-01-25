using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {


	public Texture2D Hud;
	public GUIStyle textStyle;
	
	Rect hudRect;
	
	Rect timeRect;
	Rect scoreRect;
	
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	
		float interfaceWidth = Screen.width/5.0f;
		float interfaceHeight = interfaceWidth * 0.364f;
		hudRect = new Rect(0, Screen.height - interfaceHeight, interfaceWidth, interfaceHeight);
		
		float timeWidth = interfaceWidth/4.0f;
		timeRect = new Rect(interfaceWidth/4.0f, Screen.height - interfaceHeight, timeWidth, interfaceHeight);
		scoreRect = new Rect(2.5f*interfaceWidth/4.0f, Screen.height - interfaceHeight, timeWidth, interfaceHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	string FormatTime(float time) {
		int secs = (int)(time % 60.0f);
		int mins = (int)(time / 60.0f);
		
		return string.Format("{0:00}:{1:00}", mins, secs);
	}
	
	void OnGUI() {
		GUI.DrawTexture (hudRect, Hud);
		
		string time = FormatTime(gameManager.GetTime ());
		GUI.Label (timeRect, time, textStyle);
		
		GUI.Label (scoreRect, gameManager.GetScore().ToString(), textStyle);
	}
}
