using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antigravity : MonoBehaviour {
	float Velocity = 0.0f;
	float mass = 0.0f;
	float drag = 0.0f;
	// Use this for initialization
	void Start () {
		mass = gameObject.GetComponent<Rigidbody> ().mass;

		drag = gameObject.GetComponent<Rigidbody> ().drag;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0,Velocity)

		//Velocity += (9.81f + (drag/mass))*Time.deltaTime;
		Velocity = +7f + Random.Range(0f,5f);
		transform.position = new Vector3((transform.position.x),((transform.position.y)+Velocity*Time.deltaTime),(transform.position.z));
	}
}
