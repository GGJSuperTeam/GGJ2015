using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeepAnimator : MonoBehaviour {
	
	public GameObject CentrePart;
	
	public Rigidbody2D customRigidbody;
	public bool noFlip = false;
	
	SpriteFacing CurrentSpriteFacing;
	Vector2 up = Vector2.up;
	Vector2 facing = Vector2.zero;
	
	bool flipped = true;//false;
	
	Animator animator;
	
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		
		if(customRigidbody == null) customRigidbody = rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
		CalculateFacing();
		CalculateLayers();
	}
	
	void CalculateLayers() {
		
	}
	
	void CalculateFacing() {
		if(customRigidbody.velocity.magnitude > 0.1f) {
			//animator.animation.PlPlay();
			facing = new Vector2(customRigidbody.velocity.x, customRigidbody.velocity.y); // update 2d vector for direction we're facing.
			
			float angle = Vector2.Angle (up, facing);
			float angDir = HelperFunctions.AngleDir(up, facing);
			
			if(angDir < 0.0f) angle = 360.0f - angle;
			
			// Bucket the shit
			var oldSpriteFacing = CurrentSpriteFacing;
			CurrentSpriteFacing = GetBucket(angle);
			
			//UpdateOffset(oldSpriteFacing);
			
			UpdateAnimation();
		} else {
			//if(animator.animation && animator.animation.isPlaying) 
			
			//if(animator.animation.isPlaying) animator.animation.Stop();
		}
		
		animator.SetFloat ("Speed", customRigidbody.velocity.magnitude);
	}
	
	void UpdateAnimation()
	{
		int face = (int)CurrentSpriteFacing;
		if (face == 3) // right
			face = 2; // there is only left
		
		animator.SetInteger("Face", face);
	}
	
	void UpdateOffset(SpriteFacing oldSpriteFacing)
	{
	
	}
	
	SpriteFacing GetBucket(float angle) {
		if (angle > 315.0f || angle < 45.0f) {
			return SpriteFacing.Up;
		}
		
		if (angle > 135.0f && angle < 225.0f) {
			return SpriteFacing.Down;
		}
		
		if(angle > 225.0f && angle < 315.0f) {
			if(flipped)
				Flip();
			return SpriteFacing.Left;
		}
		
		if(angle > 45.0f && angle < 135.0f) {
			if(!flipped)
				Flip();
			return SpriteFacing.Right;
		}
		
		return 0;
	}
	
	void Flip() {
		if(!noFlip) {
			flipped = !flipped;
			Vector3 newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			transform.localScale = newScale;
		}
	}
}
