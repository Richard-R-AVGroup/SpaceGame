using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDropHandler : MonoBehaviour {

	private Rigidbody mainRigidbody;
	public BoxCollider objectCollider;
	public MeshCollider collisionCollider;

	// Use this for initialization
	void Start () {
		mainRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {//player walks into area, turns on gravity for the object to fall
			mainRigidbody.useGravity = true;
			mainRigidbody.isKinematic = false;
			StartCoroutine ("DestroyCollision");
		}
	}

	IEnumerator DestroyCollision(){
		yield return new WaitForSeconds (1.0f);//stopping the object from blocking the player after a short period
		Destroy (mainRigidbody);
		Destroy (objectCollider);
		Destroy (collisionCollider);
	}
}
