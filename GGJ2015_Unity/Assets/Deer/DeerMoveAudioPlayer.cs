using UnityEngine;
using System.Collections;

public class DeerMoveAudioPlayer : MonoBehaviour {

	public AudioClip[] MoveSounds;
	public Rigidbody2D customRigidbody;
	
	
	private float clopTime = 0.2f;
	private float clopTimer = 0.0f;

	private float accelAffect = 0.1f;
	private float accelModifier = 0.0f;
	private Vector3 prevVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateAcceleration();
		UpdateMoveSounds();
	}
	
	void UpdateMoveSounds() {
		if(customRigidbody.velocity.magnitude > 0.1f) {
			clopTimer -= Time.deltaTime;
			if(clopTimer <= 0.0f) {
				AudioSource.PlayClipAtPoint(GetRandomMoveSound(), transform.position);
				clopTimer = clopTime + Random.value * clopTime/2.0f + accelModifier;
			}
		}
	}
	
	AudioClip GetRandomMoveSound() {
		return MoveSounds[Random.Range (0, MoveSounds.Length)];
	}
	
	void UpdateAcceleration() {
		Vector3 currVelocity = customRigidbody.velocity;
		float accel = ((currVelocity - prevVelocity)/Time.deltaTime).magnitude;
		
		accelModifier = customRigidbody.velocity.magnitude/10.0f * accelAffect;//accelAffect * accel;
		
		prevVelocity = currVelocity;
	}
}
