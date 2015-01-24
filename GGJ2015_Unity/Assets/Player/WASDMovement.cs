using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public bool physics = true;
	public float speed = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement();
	}
	
	void HandleMovement() {
		if(Input.GetKey (KeyCode.UpArrow)) {
			if(physics) rigidbody.AddForce (transform.up * speed);
			else transform.Translate(transform.up * speed * Time.deltaTime); 
		}
		
		if(Input.GetKey (KeyCode.DownArrow)) {
			if(physics) rigidbody.AddForce (-transform.up * speed);
			else transform.Translate(-transform.up * speed * Time.deltaTime); 
		}
		
		if(Input.GetKey (KeyCode.LeftArrow)) {
			if(physics) rigidbody.AddForce (-transform.right * speed);
			else transform.Translate(-transform.right * speed * Time.deltaTime); 
		}
		
		if(Input.GetKey (KeyCode.RightArrow)) {
			if(physics) rigidbody.AddForce (transform.right * speed);
			else transform.Translate(transform.right * speed * Time.deltaTime); 
		}
	}
}
