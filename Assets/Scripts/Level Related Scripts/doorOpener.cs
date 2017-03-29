using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour {

	//Make an empty game object and call it "Door"
	//Rename your 3D door model to "Body"
	//Parent a "Body" object to "Door"
	//Make sure thet a "Door" object is in left down corner of "Body" object. The place where a Door Hinge need be
	//Add a box collider to "Door" object and make it much bigger then the "Body" model, mark it trigger
	//Assign this script to a "Door" game object that have box collider with trigger enabled
	//Press "f" to open the door and "g" to close the door
	//Make sure the main character is tagged "player"

	//Smoothly open door
	float smooth = 2.0f;
	float doorOpenAngle = 90.0f;
	private bool open;
	private bool enter;

	private Vector3 defaultRot;
	private Vector3 openRot;

	public bool Openable;

	// Use this for initialization
	void Start () {
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Openable == true) {//if the door is set to be able to be opened
			if (open == true) {//open door
				transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, openRot, Time.deltaTime * smooth);
			} else { //close door
				transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
			}

			if (Input.GetKeyDown ("g") && enter) {
				open = !open;
			}
		}
	}

	//Toggles door to openable if player is near
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			enter = true;
		}
	}

	//toggles once player is away
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			enter = false;
		}
	}
}
