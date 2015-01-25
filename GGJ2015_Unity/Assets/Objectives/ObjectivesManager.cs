using UnityEngine;
using System.Collections;

public class ObjectivesManager : MonoBehaviour {
	
	enum ObjState { none, alert, warm, find, turnin }
	
	public Texture2D StartIcon;
	public Texture2D EndIcon;
	public Texture2D[] Icons;
	public GameObject[] Objectives;
	public GameObject TurninObject;
	
	ObjState state = ObjState.none;
	
	/*public GameObject Copier;
	public GameObject CoffeePot;
	public GameObject WaterCooler;
	public GameObject FilingCabinet;
	public GameObject Phone;
	public GameObject Computer;*/
	
	int objectiveIndex = -1;
	int iconIndex = -1;
	
	GameManager gameManager;	

	Rect currIconPos;
	Rect startIconPos;
	Rect targetIconPos;
	
	float iconWidth;
	
	float waitTime = 1.0f;
	float waitTimer = 0.0f;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent <GameManager>();
		
		iconWidth = Screen.width/25.0f;
		
		startIconPos = new Rect(Screen.width/2.0f - iconWidth/2.0f, iconWidth, iconWidth, iconWidth);
		
		CreateObjective();
	}
	
	// Update is called once per frame
	void Update () {
		if(waitTimer > 0.0f) {
			waitTimer -= Time.deltaTime;
			if(waitTimer <= 0.0f) {
				if(state == ObjState.alert) ActivateObjective();
				else if(state == ObjState.warm) state = ObjState.find;
			} 
		} else if(objectiveIndex >= 0 && (state == ObjState.find || state == ObjState.turnin)){
			UpdateTargetIconPosition();
			UpdateCurrentIcon();
		} 
	}

	void UpdateTargetIconPosition() {
		Vector3 targ = Objectives[objectiveIndex].transform.position;
		if(state == ObjState.turnin) targ = TurninObject.transform.position;
		
		Vector3 viewPos = Camera.main.WorldToScreenPoint(targ);
		viewPos.y = Screen.height - viewPos.y;
		
		Debug.Log ("viewPos = " + viewPos);
		
		viewPos.x = Mathf.Clamp(viewPos.x, 5.0f, Screen.width - targetIconPos.width);
		viewPos.y = Mathf.Clamp(viewPos.y, 5.0f, Screen.width - targetIconPos.width);
		
		/*if(viewPos.x < -1.0f) viewPos.x = -1.0f;
		if(viewPos.x > 1.0f) viewPos.x = 1.0f;
		
		if(viewPos.y < -1.0f) viewPos.y = -1.0f;
		if(viewPos.y > 1.0f) viewPos.y = 1.0f;*/
		
		targetIconPos.x = viewPos.x;// * Screen.width ;
		targetIconPos.y = viewPos.y;// * Screen.height;
	}
	
	void UpdateCurrentIcon() {
		Vector2 currPos = new Vector2(currIconPos.x, currIconPos.y);
		Vector2 targPos = new Vector2(targetIconPos.x, targetIconPos.y);
		
		currPos = Vector2.Lerp (currPos, targPos, Time.deltaTime * 10.0f);
		
		currIconPos.x = currPos.x;
		currIconPos.y = currPos.y;
	}
	
	void CreateObjective() {
		currIconPos = startIconPos;
		targetIconPos = startIconPos;
		
		waitTimer = waitTime;
	
		objectiveIndex = Random.Range (0, Objectives.Length);
		
		iconIndex = objectiveIndex;
		if(objectiveIndex > Icons.Length) iconIndex = Icons.Length-1;
		
		state = ObjState.alert;
	}
	
	void ActivateObjective() {
		Objectives[objectiveIndex].GetComponent<Objective>().objectiveActive = true;
		
		waitTimer = waitTime;
		
		state = ObjState.warm;
	}
	
	public void PickupObjective() {
		Objectives[objectiveIndex].GetComponent<Objective>().objectiveActive = false;
		TurninObject.GetComponent<Objective>().objectiveActive = true;
		
		state = ObjState.turnin;
	}
	
	public void CompleteObjective() {
		gameManager.AddTime(20.0f);
		
		Objectives[objectiveIndex].GetComponent<Objective>().objectiveActive = false;
		
		CreateObjective();
	}
	
	void OnGUI() {
		if (state == ObjState.alert) {
			GUI.DrawTexture (currIconPos, StartIcon);
		} else if (state == ObjState.turnin) {
			GUI.DrawTexture (currIconPos, EndIcon);
		} else if (state != ObjState.none && state != ObjState.alert) {
			GUI.DrawTexture (currIconPos, Icons[iconIndex]);
		}
	}
}
