using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOnScript : MonoBehaviour {

	public BoxCollider collisionCollider;

	private bool inSpace = false;

	private GameObject[] RegLights;
	private GameObject[] EmergLights;

	// Use this for initialization
	void Start () {
		RegLights = GameObject.FindGameObjectsWithTag ("Lights");

		EmergLights = GameObject.FindGameObjectsWithTag ("EmergencyLights");

		for (int i = 0; i < RegLights.Length; i++) {
			if (RegLights [i].GetComponent<LightFlicker> ()) { //seeing if the light has the flicker script attached, and leaves it on if so

			} else {
				RegLights [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G) && inSpace == true) {
			for (int i = 0; i < EmergLights.Length; i++) {
				EmergLights [i].SetActive (false);
			}
			for (int i = 0; i < RegLights.Length; i++) {
				RegLights [i].SetActive (true);
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			inSpace = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			inSpace = false;
		}
	}
}
