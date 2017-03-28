using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHandler : MonoBehaviour {

	public static movementHandler Instance;

	public float moveSpeed;
	private float defaultMoveSpeed;
	public float rotationSpeed;

	private float jumpSpeed;

	public bool hasFlashlight = false;
	private bool flashlightOn = false;
	public Light flashlight;

	// Use this for initialization
	void Start () {
		Instance = this;
		flashlight.enabled = false;
		Cursor.lockState = CursorLockMode.Locked;
		defaultMoveSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) { //Forward
			transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey ("s")) { //Back
			transform.Translate (-Vector3.forward * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey ("a")) { //left
			transform.Translate (-Vector3.right * Time.deltaTime * moveSpeed);
		}
		if (Input.GetKey ("d")) {//right
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		}

		if (Input.GetKey(KeyCode.LeftShift)) {//sprinting TODO, add a restriction to sprint
			moveSpeed = defaultMoveSpeed * 2;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {//reseting speed after sprint is relesed
			moveSpeed = defaultMoveSpeed;
		}

		if (hasFlashlight == true) {//if the player has picked up the flashlight object
			if (Input.GetKeyDown ("f")) {//turning on flashlight
				if (flashlightOn == true) {
					flashlight.enabled = false;
					flashlightOn = false;
				} else if (flashlightOn == false) {
					flashlight.enabled = true;
					flashlightOn = true;
				}
			}
		}
	}
}
