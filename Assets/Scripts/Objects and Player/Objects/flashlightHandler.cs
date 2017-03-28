using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlightHandler : MonoBehaviour {

	public Shader shaderDefault;
	public Renderer rend;

	private bool highlighted = false;

	private GameObject playerMain;
	private float distToPlayer;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		shaderDefault = rend.material.shader;//getting the default shader

		playerMain = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distToPlayer = Vector3.Distance(playerMain.transform.position, transform.position);
	}

	void OnMouseOver() {
		if (distToPlayer <= 2f) {
			rend.material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");//switching to the highlighted shader version

			if (movementHandler.Instance.hasFlashlight != true) {//making it so when the flashlight is picked up, the cursor is able to swap bac
				uiHandler.Instance.defaultCenterCursor.SetActive (false);
				uiHandler.Instance.pickupCenterCursor.SetActive (true);
			}

			highlighted = true;
		}
	}

	void OnMouseExit() {
		rend.material.shader = shaderDefault;//switching back to the regular shader version
		uiHandler.Instance.defaultCenterCursor.SetActive (true);
		uiHandler.Instance.pickupCenterCursor.SetActive (false);

		highlighted = false;
	}

	void OnMouseDown() {
		if (highlighted == true) {//if the object is highlighted when clicked on it gets picked up
			movementHandler.Instance.hasFlashlight = true;
			uiHandler.Instance.defaultCenterCursor.SetActive (true);
			uiHandler.Instance.pickupCenterCursor.SetActive (false);

			Destroy(this.gameObject);
		}
	}
}
