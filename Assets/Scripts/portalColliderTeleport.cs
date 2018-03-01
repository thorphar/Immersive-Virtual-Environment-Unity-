using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalColliderTeleport : MonoBehaviour {

	public GameObject from;
	public GameObject to;
	public GameObject player;
	public GameObject playerCamera;


	private static int inUse = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (inUse == 3) inUse = 0;
		if (inUse == 0)
		{
			inUse = 1;
			teleport();
		}
	}

	void OnTriggerExit(Collider other)
	{
		inUse ++;
	}

	void teleport()
	{
		Vector3 posConst = to.transform.position - from.transform.position;
		Vector3 rotConst = (to.transform.eulerAngles - from.transform.eulerAngles) - new Vector3(0,180,0);
		Vector3 scaleConst = to.transform.localScale - from.transform.localScale;

		Debug.Log("to: " + to.transform.eulerAngles + " ,from: " + from.transform.eulerAngles + ", const: " + rotConst);

		player.transform.position += posConst;

		playerCamera.transform.eulerAngles += rotConst;
		playerCamera.GetComponent<CameraBehaviourScript>().resetVar(rotConst);

		player.transform.localScale += scaleConst;
		playerCamera.transform.localScale += scaleConst;
	}
}
