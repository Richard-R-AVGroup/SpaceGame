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
			if (Input.GetKeyDown (KeyCode.F)) {
				if (pickedUp == false) {
					pickedUp = true;
					mainRigd.constraints = RigidbodyConstraints.FreezeRotation;//freezing rotation
					mainRigd.useGravity = false;//disabling gravity
					uiHandler.Instance.defaultCenterCursor.SetActive (true);//turning of ui grab element
					uiHandler.Instance.pickupCenterCursor.SetActive (false);
					movementHandler.Instance.boxPickedUp = true;
				}
			}
			if (pickedUp == true) {
				if (Input.GetKeyDown (KeyCode.Q)) {//dropping the box
					pickedUp = false;
					mainRigd.constraints = RigidbodyConstraints.None;//removing all rigidbody constraints
					mainRigd.useGravity = true;//turning gravity back on
					movementHandler.Instance.boxPickedUp = false;
					pickupScaling.Instance.scrollDistScaler = 4.0f;//reseting the scroll scaler to default distance (4)
				}
			}
		}

		if (pickedUp == true) {
			transform.position = Vector3.MoveTowards (this.transform.position, boxHoldPos.transform.position, speed * Time.deltaTime);// moving towards the box holding position(child of the player object)
			highlighted = true;//ensuring the box is permantly highlighted
		}

		if (distToPlayer >= 5f && pickedUp != true) {//only allowing the player to grab the box within a certain distance
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
					uiHandler.Instance.defaultCenterCursor.SetActive (false);
					uiHandler.Instance.pickupCenterCursor.SetActive (true);
					highlighted = true;
				}
			}
		}
	}

	void OnMouseExit() {
		if (pickedUp == false) {
			if (movementHandler.Instance.boxPickedUp == false) {
				rend.material.shader = shaderDefault;//switching back to the regular shader version
				uiHandler.Instance.defaultCenterCursor.SetActive (true);
				uiHandler.Instance.pickupCenterCursor.SetActive (false);

				highlighted = false;
			}
		}
	}
}
