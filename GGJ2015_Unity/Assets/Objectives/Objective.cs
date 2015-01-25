using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

	public bool objectiveActive = false;
	public bool isTurnin = false;

	ObjectivesManager objectivesManager;

	// Use this for initialization
	void Start () {
		objectivesManager = GameObject.Find ("ObjectivesManager").GetComponent <ObjectivesManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(objectiveActive && other.gameObject.tag == "Deer") {
			if(!isTurnin) objectivesManager.PickupObjective();
			else objectivesManager.CompleteObjective();
		}
	}
}
