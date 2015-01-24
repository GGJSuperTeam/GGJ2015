using UnityEngine;
using System.Collections;

public class ExplodingObstacle : MonoBehaviour {

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Deer" && Explosion != null) {
			Instantiate(Explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
