using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float speed = 1.0f;
	
	private Vector3 self;
	private Vector3 targ;

	// Use this for initialization
	void Start () {
		self = new Vector2(transform.position.x, transform.position.y);
		targ = new Vector2(target.position.x, target.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null) {
			self.x = transform.position.x;
			self.y = transform.position.y;
			targ.x = target.position.x;
			targ.y = target.position.y;
			
			Vector2 diff = targ - self;
			
			Vector3 diff3 = new Vector3(diff.x, diff.y, 0);
			transform.position += diff3 * speed * Time.deltaTime;
		}
	}
}
