using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public Texture2D splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire1")) {
			Application.LoadLevel (1);
		}
		
		if(Input.GetKeyDown (KeyCode.Escape)) Application.Quit ();
	}
	
	void OnGUI() {
		float width = Screen.width * (splash.width/splash.height);
		GUI.DrawTexture (new Rect(Screen.width/2.0f - width/2.0f,0,width,Screen.height), splash);
	}
}
