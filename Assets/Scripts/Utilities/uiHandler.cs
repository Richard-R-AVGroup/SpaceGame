using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiHandler : MonoBehaviour {

	public static uiHandler Instance;

	public GameObject defaultCenterCursor;
	public GameObject pickupCenterCursor;

	// Use this for initialization
	void Start () {
		Instance = this;

		defaultCenterCursor = GameObject.Find ("defaultCenterCursor");
		pickupCenterCursor = GameObject.Find ("pickupCenterCursor");

		pickupCenterCursor.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit() {
		Time.timeScale = 1;
		Application.Quit ();
	}
}
