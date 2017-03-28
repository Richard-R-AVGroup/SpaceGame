using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMover : MonoBehaviour {

	private Rigidbody mainRigd;

	private GameObject defaultCenterCursor;
	private GameObject pickupCenterCursor;

	public Shader shaderDefault;
	public Renderer rend;

	private bool highlighted = false;
	private bool pickedUp = false;

	private GameObject boxHoldPos;
	public float speed = 4.0f;

	// Use this for initialization
	void Start () {
		mainRigd = GetComponent<Rigidbody> ();
		rend = GetComponent<Renderer>();
		shaderDefault = rend.material.shader;//getting the default shader

		defaultCenterCursor = GameObject.Find ("defaultCenterCursor");
		pickupCenterCursor = GameObject.Find ("pickupCenterCursor");
		pickupCenterCursor.SetActive (false);

		boxHoldPos = GameObject.Find ("BoxHoldPos");
	}
	
	// Update is called once per frame
	void Update () {
		if (highlighted == true) {
			if (Input.GetKeyDown (KeyCode.G)) {
				if (pickedUp == false) {
					pickedUp = true;
					mainRigd.constraints = RigidbodyConstraints.FreezeRotation;
					mainRigd.useGravity = false;
					defaultCenterCursor.SetActive (true);
					pickupCenterCursor.SetActive (false);
				} else {
					pickedUp = false;
					mainRigd.constraints = RigidbodyConstraints.None;
					mainRigd.useGravity = true;
				}
			}
		}

		if (pickedUp == true) {
			transform.position = Vector3.MoveTowards (this.transform.position, boxHoldPos.transform.position, speed * Time.deltaTime);
		}
	}

	void OnMouseOver() {
		if (pickedUp == false) {
			rend.material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");//switching to the highlighted shader version

			if (movementHandler.Instance.hasFlashlight != true) {//making it so when the flashlight is picked up, the cursor is able to swap bac
				defaultCenterCursor.SetActive (false);
				pickupCenterCursor.SetActive (true);
			}

			highlighted = true;
		}
	}

	void OnMouseExit() {
		if (pickedUp == false) {
			rend.material.shader = shaderDefault;//switching back to the regular shader version
			defaultCenterCursor.SetActive (true);
			pickupCenterCursor.SetActive (false);

			highlighted = false;
		}
	}
}
