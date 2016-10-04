using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.tag == "cylinder") {
			other.gameObject.GetComponent<cylinderFollow>().enabled = true;

		}
	}
}
