using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoorOpen : MonoBehaviour {

	public bool isLocked = false;
	public bool hasKeycard = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		if (isLocked == false) {
			GameObject thedoor = GameObject.FindWithTag ("SF_Door");
			thedoor.GetComponent<Animation> ().Play ("open");
		} else {
			if (hasKeycard == true) {
				GameObject thedoor = GameObject.FindWithTag ("SF_Door");
				thedoor.GetComponent<Animation> ().Play ("open");
			} else {

			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (isLocked == false) {
			GameObject thedoor = GameObject.FindWithTag ("SF_Door");
			thedoor.GetComponent<Animation> ().Play ("close");
		} else {
			if (hasKeycard == true) {
				GameObject thedoor = GameObject.FindWithTag ("SF_Door");
				thedoor.GetComponent<Animation> ().Play ("close");
			} else {

			}
		}
	}
}
