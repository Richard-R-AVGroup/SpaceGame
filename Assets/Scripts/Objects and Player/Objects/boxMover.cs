using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMover : MonoBehaviour {

	private Rigidbody mainRigd;

	public Shader shaderDefault;
	public Renderer rend;

	private bool highlighted = false;
	private bool pickedUp = false;

	private GameObject boxHoldPos;

	private GameObject playerMain;

	public float speed = 4.0f;

	private float distToPlayer;

	// Use this for initialization
	void Start () {
		mainRigd = GetComponent<Rigidbody> ();
		rend = GetComponent<Renderer>();
		shaderDefault = rend.material.shader;//getting the default shader

		boxHoldPos = GameObject.Find ("BoxHoldPos");

		playerMain = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distToPlayer = Vector3.Distance(playerMain.transform.position, transform.position);

		if (highlighted == true) {
			if (Input.GetKeyDown (KeyCode.G)) {
				if (pickedUp == false) {
					pickedUp = true;
					mainRigd.constraints = RigidbodyConstraints.FreezeRotation;
					mainRigd.useGravity = false;
					uiHandler.Instance.defaultCenterCursor.SetActive (true);
					uiHandler.Instance.pickupCenterCursor.SetActive (false);
					movementHandler.Instance.boxPickedUp = true;
				} else {
					pickedUp = false;
					mainRigd.constraints = RigidbodyConstraints.None;
					mainRigd.useGravity = true;
					movementHandler.Instance.boxPickedUp = false;
					pickupScaling.Instance.scrollDistScaler = 4.0f;
				}
			}
		}

		if (pickedUp == true) {
			transform.position = Vector3.MoveTowards (this.transform.position, boxHoldPos.transform.position, speed * Time.deltaTime);

			highlighted = true;
		}

		if (distToPlayer >= 5f) {
			rend.material.shader = shaderDefault;//switching back to the regular shader version
			uiHandler.Instance.defaultCenterCursor.SetActive (true);
			uiHandler.Instance.pickupCenterCursor.SetActive (false);

			highlighted = false;
		}
	}

	void OnMouseOver() {
		if (distToPlayer <= 5f) {
			if (movementHandler.Instance.boxPickedUp == false) {
				if (pickedUp == false) {
					rend.material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");//switching to the highlighted shader version

					if (movementHandler.Instance.hasFlashlight != true) {//making it so when the flashlight is picked up, the cursor is able to swap bac
						uiHandler.Instance.defaultCenterCursor.SetActive (false);
						uiHandler.Instance.pickupCenterCursor.SetActive (true);
					}

					highlighted = true;
				}
			}
		}
	}

	void OnMouseExit() {
		if (pickedUp == false) {
			rend.material.shader = shaderDefault;//switching back to the regular shader version
			uiHandler.Instance.defaultCenterCursor.SetActive (true);
			uiHandler.Instance.pickupCenterCursor.SetActive (false);

			highlighted = false;
		}
	}
}
