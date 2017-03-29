using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScaling : MonoBehaviour {

	/**
	 * SCRIPT FOR SCALING THE BOX MOVING LOCATION BASED ON:
	 * player height, camera angle, distance
	 * WEIRD AS FUCK MATH, Probably shouldn't mess with it without talking to me(Harrison)
	 **/


	public static pickupScaling Instance;

	public float scrollDistScaler = 4.0f;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		float newYPos = (0.404f * ((MouseLook.Instance.rotationY / 9f) + 1f ));
		//Debug.Log (newYPos);
		transform.localPosition = new Vector3 (transform.localPosition.x, newYPos, (scrollDistScaler));

		if (movementHandler.Instance.boxPickedUp == true) {
			//scrolling the mouse wheel to move box away or closer to player
			scrollDistScaler += Input.GetAxis ("Mouse ScrollWheel");
			scrollDistScaler = Mathf.Clamp (scrollDistScaler, 2.0f, 8.0f);
		}
	}
}
