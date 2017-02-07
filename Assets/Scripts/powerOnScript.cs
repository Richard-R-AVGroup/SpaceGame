using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOnScript : MonoBehaviour {

	public BoxCollider collisionCollider;

	private bool inSpace = false;

	private GameObject[] RegLights;
	private GameObject[] EmergLights;

	private bool LightsOn = false;

	private float delay = 0;

	public AudioClip switchFlip;
	public AudioClip LightOnSound;

	private AudioSource audioMain;

	// Use this for initialization
	void Start () {
		audioMain = GetComponent<AudioSource> ();

		RegLights = GameObject.FindGameObjectsWithTag ("Lights");

		EmergLights = GameObject.FindGameObjectsWithTag ("EmergencyLights");

		for (int i = 0; i < RegLights.Length; i++) {
			if (RegLights [i].GetComponent<LightFlicker> ()) { //seeing if the light has the flicker script attached, and leaves it on if so

			} else {
				RegLights [i].SetActive (false);//turning off lights
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G) && inSpace == true) {//turing on the lights
			LightsOn = true;
			audioMain.clip = switchFlip;
			audioMain.Play ();
		}

		if (LightsOn == true) {
			for (int i = 0; i < EmergLights.Length; i++) {//just turning off all emergency lights immediatly
				EmergLights [i].SetActive (false);
			}
			for (int i = 0; i < RegLights.Length; i++) {//delaying the turn on of other lights, so creates a staged effect
				delay += 0.75f;
				StartCoroutine(delayLightTurnOn(i));

				if (i == RegLights.Length - 1) { 
					LightsOn = false;
				}
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

	IEnumerator delayLightTurnOn(int i) {
		yield return new WaitForSeconds (delay);
		RegLights [i].SetActive (true);
		AudioSource.PlayClipAtPoint (LightOnSound, RegLights [i].transform.position);
	}
}
