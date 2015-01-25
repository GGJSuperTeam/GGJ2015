using UnityEngine;
using System.Collections;

public class DeerBumpAudioPlayer : MonoBehaviour {

	public AudioClip[] DeerSounds;
	
	float betweenTime = 0.9f;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		timer = betweenTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
	}

	AudioClip GetRandomSound() {
		return DeerSounds[Random.Range (0, DeerSounds.Length)];
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if(timer <= 0.0f && coll.gameObject.tag != "Deer") {
			AudioSource.PlayClipAtPoint(GetRandomSound(), transform.position);
			timer = betweenTime;
		}
	}
}
