using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlightHandler : MonoBehaviour {

	private GameObject defaultCenterCursor;
	private GameObject pickupCenterCursor;

	public Shader shaderDefault;
	public Renderer rend;

	private bool highlighted = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		shaderDefault = rend.material.shader;//getting the default shader

		defaultCenterCursor = GameObject.Find ("defaultCenterCursor");
		pickupCenterCursor = GameObject.Find ("pickupCenterCursor");
		pickupCenterCursor.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver() {
		rend.material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");//switching to the highlighted shader version

		if (movementHandler.Instance.hasFlashlight != true) {//making it so when the flashlight is picked up, the cursor is able to swap bac
			defaultCenterCursor.SetActive (false);
			pickupCenterCursor.SetActive (true);
		}

		highlighted = true;
	}

	void OnMouseExit() {
		rend.material.shader = shaderDefault;//switching back to the regular shader version
		defaultCenterCursor.SetActive (true);
		pickupCenterCursor.SetActive (false);

		highlighted = false;
	}

	void OnMouseDown() {
		if (highlighted == true) {//if the object is highlighted when clicked on it gets picked up
			movementHandler.Instance.hasFlashlight = true;
			defaultCenterCursor.SetActive (true);
			pickupCenterCursor.SetActive (false);

			Destroy(this.gameObject);
		}
	}
}
