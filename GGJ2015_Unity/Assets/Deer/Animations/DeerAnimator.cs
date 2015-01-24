using UnityEngine;
using System.Collections;

public class DeerAnimator : MonoBehaviour {

	public int face = 0;	
	
	private Vector2 up = Vector2.up;
	private Vector2 facing = Vector2.zero;
	
	private bool flipped = false;
	
	private Animator animator;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		CalculateFace();
	}
	
	void CalculateFace() {
		facing = new Vector2(transform.up.x, transform.up.y); // update 2d vector for direction we're facing.
		
		float angle = Vector2.Angle (up, facing);
		float angDir = HelperFunctions.AngleDir(up, facing);
		
		if(angDir < 0.0f) angle = 360.0f - angle;
		
		// Bucket the shit
		face = GetBucket(angle);
		
		animator.SetInteger("Face", face);
	}
	
	int GetBucket(float angle) {
		if(angle > 315.0f || angle < 45.0f) return 0; // up
		
		if(angle > 135.0f && angle < 225.0f) return 1; // down
		
		if(angle > 225.0f && angle < 315.0f) { // left
			if(flipped) Flip();
			return 2; 
		}
		
		if(angle > 45.0f && angle < 135.0f) { // right
			if(!flipped) Flip();
			return 2;
		}
		
		return 0;
	}
	
	void Flip() {
		flipped = !flipped;
		Vector3 newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		transform.localScale = newScale;
	}
}
