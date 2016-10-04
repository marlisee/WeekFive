using UnityEngine;
using System.Collections;

public class MoveCrane : MonoBehaviour {

	public float speed = 20f; 
	public float dipspeed;
	public float delay;
	public ParticleSystem particles;
	private bool first = false;
	private bool second = false;
	private bool third = false;
	private bool dipping = false;
	private bool rising = false;
	private bool returning1 = false;
	private bool returning2 = false;
	private Rigidbody rb;
	// Use this for initialization
	
	void Update() {
		if (Input.GetKey("1")) {
			if (!first)
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
		if (Input.GetKeyUp ("1")) {
			first = true;
		}
		if (Input.GetKey ("2")) {
			if (first && !second)
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (Input.GetKeyUp ("2")) {
			second = true;
		}

		if (Input.GetKeyDown ("3")) {
			if (first && second && !third)
				StartCoroutine ("dip");
		}

		if (Input.GetKeyUp ("3")) {
			third = true;
		}

		if (Input.GetKey ("0")) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (dipping) {
			if (transform.position.y > 5.25f)
				transform.Translate (Vector3.up * -speed * Time.deltaTime);
		}
		if (rising) {
			if (transform.position.y < 18)
				transform.Translate (Vector3.up * speed * Time.deltaTime);
			else
				returning1 = true;
		}

		if (returning1) {
			if (transform.position.x > -9.17f)
				transform.Translate (Vector3.right * -dipspeed * Time.deltaTime);
			else {
				returning1 = false;
				returning2 = true;
			}
		}

		if (returning2) {
			if (transform.position.z > 3.73f)
				transform.Translate (Vector3.forward * -dipspeed * Time.deltaTime);
			else {
				returning2 = false;
				rb.isKinematic = false;
				particles.gameObject.SetActive (true);
			}
		}
}

	void OnTriggerEnter(Collider other )
	{
		if (other.gameObject.transform.tag == "ball") {
			print ("xd");
			other.gameObject.transform.parent = this.transform;
			rb = other.gameObject.GetComponent<Rigidbody>();
			rb.isKinematic = true;
		}
	}
	IEnumerator dip() {
		dipping = true;
		rising = false;
		yield return new WaitForSeconds(delay);
		dipping = false;
		rising = true;

}
}
