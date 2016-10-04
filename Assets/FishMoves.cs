using UnityEngine;
using System.Collections;

public class FishMoves : MonoBehaviour {

	//const is opional, but it tells the computer that the value won't change 
	//declare state constants 


		private const int WAITING_ON_LURE = 0; 
		private const int FOLLOWING_LURE = 1; 
		private const int CAUGHT_ON_LURE = 2; 
		//state variable to determine behaviour; 
		private int state = WAITING_ON_LURE;
		private float fishSpeed = 2; 
		private Transform lurePosition;


		// Use this for initialization
	void Start () {
		
	}
		
		// Update is called once per frame
	void Update () {

		//the most efficient way of writing this is with a switch statement. If, else if works just fine though, and is only nominally slower 

		if (state == WAITING_ON_LURE) {

		} else if (state == FOLLOWING_LURE) {
			transform.LookAt (lurePosition); 
			transform.position += transform.forward * Time.deltaTime * fishSpeed; 

		} else if (state == CAUGHT_ON_LURE) {
			transform.position = lurePosition.position; 
		}
	}


	void OnTriggerEnter(Collider otherCollider){
		state = FOLLOWING_LURE; 
		lurePosition = otherCollider.transform; 
		}

	void OnTriggerExit () {
		state = WAITING_ON_LURE;
		GetComponent<Rigidbody> ().isKinematic = false;

	}

	void OnCollisionEnter(Collision collisionData) {
		Debug.Log ("caught fish!");
		state = CAUGHT_ON_LURE; 
		lurePosition = collisionData.transform; 
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}

