using UnityEngine;
using System.Collections;

public class ZSort : MonoBehaviour {
	
	public float offset = 0.0f;
	
	private Vector3 newPos = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
		float z = -transform.position.y - offset;
		newPos.x = transform.position.x;
		newPos.y = transform.position.y;
		newPos.z = z;
		transform.position = newPos;
	}
}
				