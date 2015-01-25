using UnityEngine;
using System.Collections;

public class DeerAnimator : MonoBehaviour {

	public int face = 0;	
	
	public Rigidbody2D customRigidbody;
	public bool noFlip = false;
	
	private Vector2 up = Vector2.up;
	private Vector2 facing = Vector2.zero;
	
	private bool flipped = false;
	
	private Animator animator;
	
	public enum DeerLayer
	{
		Deer0,
		Deer1,
		Deer2,
		Deer3,
	}
	
	public DeerLayer regularLayer;
	public DeerLayer oppositeLayer;
	
	static string GetLayerName(DeerLayer layer)
	{
		switch (layer)
		{
		case DeerLayer.Deer0:
			return "Deer0";
		case DeerLayer.Deer1:
			return "Deer1";
		case DeerLayer.Deer2:
			return "Deer2";
		case DeerLayer.Deer3:
			return "Deer3";
		default:
			return "Default";
		}
	}

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
		
		if(customRigidbody == null)  customRigidbody = rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
		CalculateFace();
		
		CalculateLayers();
	}
	
	void CalculateLayers() {
		if (face == 0) // going up
			this.renderer.sortingLayerName = GetLayerName(oppositeLayer);
		else
			this.renderer.sortingLayerName = GetLayerName(regularLayer);
	}
	
	void CalculateFace() {
		if(customRigidbody.velocity.magnitude > 0.1f) {
			facing = new Vector2(customRigidbody.velocity.x, customRigidbody.velocity.y); // update 2d vector for direction we're facing.
			
			float angle = Vector2.Angle (up, facing);
			float angDir = HelperFunctions.AngleDir(up, facing);
			
			if(angDir < 0.0f) angle = 360.0f - angle;
			
			// Bucket the shit
			face = GetBucket(angle);
			
			animator.SetInteger("Face", face);
		}
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
		if(!noFlip) {
			flipped = !flipped;
			Vector3 newScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			transform.localScale = newScale;
		}
	}
}
