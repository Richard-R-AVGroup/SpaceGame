using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScaling : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float newYPos = (0.404f * ((MouseLook.Instance.rotationY / 10) + 3 )) + ((GameObject.Find("Player").transform.position.y) - 0.63f);
		//Debug.Log (newYPos);
		transform.position = new Vector3 (transform.position.x, newYPos, transform.position.z);
	}
}
