using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

	public bool wander = true;
	
	public Transform[] waypoints;

	public float speed = 100.0f;

	// Wander stuff
	private float baseWanderTime = 1.0f;
	private float timer = 0.0f;
	
	private bool wait = true;
	private Vector3 currDirection = Vector3.zero;
	
	// Waypoint Stuff
	private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
		DecideNewAction();
	}
	
	// Update is called once per frame
	void Update () {
		if(wander) UpdateWander();
		else if(waypoints.Length > 0) UpdatePath();
	}
	
	void UpdateWander() {
		Debug.Log("Updating Wander");
		timer -= Time.deltaTime;
		if(timer <= 0.0f) {
			DecideNewAction();
		}
		
		if(!wait) {
			rigidbody2D.AddForce (currDirection * speed);
		}
	}
	
	void DecideNewAction() {
		Debug.Log ("deciding new action");
		float rnd = Random.value;
		if(rnd < 0.2f) { wait = true; }
		else {
			wait = false;
			currDirection = GetRandomDir();
		}
		
		timer = baseWanderTime + Random.value * baseWanderTime * 3.0f;
	}
	
	Vector3 GetRandomDir() {
		int dir = Random.Range (0,4);
		
		Vector2 dir2D = Vector2.zero;
		
		if(dir == 0) dir2D = Vector2.up; // up 
		if(dir == 1) dir2D = -Vector2.up; // down
		if(dir == 2) dir2D = -Vector2.right; // left
		if(dir == 3) dir2D = Vector2.right; // right
		
		return new Vector3(dir2D.x, dir2D.y, 0);
	}
	
	void UpdatePath() {
		Vector3 dir = waypoints[waypointIndex].position - transform.position;
		dir.z = 0;
		
		float dist = dir.magnitude;
		
		dir = dir.normalized;
		
		rigidbody2D.AddForce (dir * speed);
		
		if(dist <= 0.5f) {
			waypointIndex += 1;
			if(waypointIndex >= waypoints.Length) waypointIndex = 0;
		}
	}
}
