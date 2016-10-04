using UnityEngine;
using System.Collections;

public class cylinderFollow : MonoBehaviour {

	public Transform thingsToFollow;
	public float speed = 1; 

	// Use this for initialization
	void Start () {
	
		transform.parent = GameObject.Find ("Cube").transform; 
	}
	
	// Update is called once per frame
	//void Update () {
	//	transform.LookAt (thingsToFollow);
	//	transform.position += transform.forward * Time.deltaTime * speed; 
	//
	//}
}
