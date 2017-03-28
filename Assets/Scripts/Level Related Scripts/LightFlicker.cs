using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	/*
	ADD THIS SCRIPT TO ANY LIGHT YOU WANT TO FLICKER
	*/
	//Light values
	private Light mainLight;

	private float timerPhaseOne = 1.0f;//timer for the first phase of the flicker, HOW LONG THE LIGHT IS OFF BETWEEN FLICKERS
	private float timerPhaseTwo = 0.5f;//timer for the second phase of the flicker, HOW LONG THE LIGHT IS ON while flickering

	public float minIntensity = 0.5f;//minimum intensity of the light
	public float maxIntensity = 2.0f;//max intesnsity of the light

	float random;

	public bool flickeringLight;
	public bool waveringLight;

	// Use this for initialization
	void Start () {
		mainLight = this.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flickeringLight == true) {
			mainLight.enabled = false;

			//counting down first phase, LIGHT IS OFF
			timerPhaseOne -= Time.deltaTime;
			if (timerPhaseOne <= 0) {
				mainLight.enabled = true;//turning the light on
				//counting down to light shut off
				timerPhaseTwo -= Time.deltaTime;
				if (timerPhaseTwo <= 0) {
					mainLight.enabled = false;//turning light back off
					//randomly selecting time for on/off
					timerPhaseTwo = Random.Range (0.5f, 4.0f);
					timerPhaseOne = Random.Range (0.5f, 8.0f);
				}
			}
			//Randomising intensity of the light with perlin Noise/Lerp
			float noise = Mathf.PerlinNoise (random, Time.time);
			mainLight.intensity = Mathf.Lerp (minIntensity, maxIntensity, noise);
		}

		if (waveringLight == true) {
			float noise = Mathf.PerlinNoise (random, Time.time);
			mainLight.intensity = Mathf.Lerp (minIntensity, maxIntensity, noise);
		}
	}
}
