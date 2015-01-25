using UnityEngine;
using System.Collections;

public class DeerNoiseAudioPlayer : MonoBehaviour {

	public AudioClip[] DeerSounds;
	public bool manual = true;


	float betweenTime = 0.5f;
	float timer = 0.0f;
	
	
	// Use this for initialization
	void Start () {
		timer = betweenTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0.0f) {
			if(manual) {
				if(Input.GetButtonDown ("Fire1")) {
					Debug.Log ("Playing noise sound");
					AudioSource.PlayClipAtPoint(GetRandomSound(), transform.position);
					timer = betweenTime;// + Random.value * betweenTime;
				}
			} else {
				AudioSource.PlayClipAtPoint(GetRandomSound(), transform.position);
				timer = betweenTime + Random.value * 5.0f;
			}
		}
 	}
 	
	AudioClip GetRandomSound() {
		return DeerSounds[Random.Range (0, DeerSounds.Length)];
	}
}
