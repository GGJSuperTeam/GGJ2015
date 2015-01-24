using UnityEngine;
using System.Collections;

public class LookMove : MonoBehaviour {

	public enum Thumbstick { Left,Right};

	// Public vars
	public float rotationSpeed = 2.0f;
	public float moveSpeed = 30.0f;
	public Thumbstick stick = Thumbstick.Left;
	public bool invertDirection = false;
	// Private vars
	Vector2 dir = Vector2.zero;
	Vector2 facing = Vector2.zero;
	
	string[] thumbstickAxes = new string[2]; // probably could more easily map these in some kind of fancy nested array.
	float invert = 1.0f;

	// Use this for initialization
	void Awake () {
		if(stick == Thumbstick.Left) {
			thumbstickAxes[0] = "Horizontal";
			thumbstickAxes[1] = "Vertical";
		} else {
			thumbstickAxes[0] = "RHorizontal";
			thumbstickAxes[1] = "RVertical";
		}
		
		if(invertDirection) invert = -1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateFacing();
		UpdateMovement();
	}
	
	// Rotates (using physics/torque) the object towards the left thumbstick direction.
	void UpdateFacing() {
		// Get left thumbstick axes
		float horz = Input.GetAxis (thumbstickAxes[0]);
		float vert = Input.GetAxis (thumbstickAxes[1]);
		// Update our direction variable with the left thumbstick axes values.
		dir.x = horz;
		dir.y = vert;
		
		// If we're past an arbitrary threshold, start facing.
		if(dir.magnitude > 0.1f) {
			facing = new Vector2(transform.up.x, transform.up.y); // update 2d vector for direction we're facing.
			
			dir.x *= invert;
			facing.y *= invert;
			//dir.x *= invert;
			//dir.y *= invert;
			
			float angle = Vector2.Angle (facing, dir);
			float angDir = HelperFunctions.AngleDir(dir, facing);
			
			// Swap them dirrrsssss if inverted!
			//facing.x *= invert;
			//facing.y *= invert;
			
			angDir *= invert;
			
			rigidbody2D.AddTorque (angDir*angle * rotationSpeed);
		}
		
		// Draw lines to see where the forward vector and input direction are
		Debug.DrawLine (transform.position, transform.position+ new Vector3(horz, vert, 0) * 2.0f, Color.red);
		Debug.DrawLine (transform.position, transform.up * 2.0f * invert, Color.blue);
	}
	
	// Push object in direction of facing.
	void UpdateMovement() {
		// Assumes facing variable was updated in the UpdateFacing() function
		if(dir.magnitude > 0.1f) {
			rigidbody2D.AddForce (facing * moveSpeed);
		}
	}
}
