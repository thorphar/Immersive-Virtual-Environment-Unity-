using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavoiur : MonoBehaviour {

	public GameObject Camera;
	public float reducer = 0.5f;
	public float sensitivity = 0.01f;
	public float movementAmount = 0.5f;

	// Use this for initialization
	void Start () {
		
	}

	void KeyboardMovement()
	{
		var movementVector = new Vector3(0f, 0f, 0f);
		var hMove = Input.GetAxis("Horizontal");
		var vMove = Input.GetAxis("Vertical");
		// left arrow
		if (hMove < -sensitivity) movementVector.x = -movementAmount * reducer;
		// right arrow
		if (hMove > sensitivity) movementVector.x = movementAmount * reducer;
		// up arrow
		if (vMove < -sensitivity) movementVector.z = -movementAmount * reducer;
		// down arrow
		if (vMove > sensitivity) movementVector.z = movementAmount * reducer;
		// Using Translate allows you to move while taking the current rotation into consideration

		//var euler = Camera.transform.rotation.eulerAngles;   //get target's rotation
		//var targetRot = Quaternion.Euler(0, euler.y, 0); //transpose values
		//transform.Translate(targetRot * movementVector);

		transform.eulerAngles = new Vector3(0, Camera.transform.eulerAngles.y, 0);
		transform.Translate(movementVector);
	}

	// Update is called once per frame
	void Update () {

		KeyboardMovement();

		if (Input.GetKey("escape")) Application.Quit();

	}
}
