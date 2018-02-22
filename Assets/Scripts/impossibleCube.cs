using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impossibleCube : MonoBehaviour {

	public int index = 0;
	private Material mat;

	// Use this for initialization
	void Start () {

		mat = this.GetComponent<MeshRenderer>().material;

		Debug.Log(mat.name);

		index = mat.renderQueue;


	}
	
	// Update is called once per frame
	void Update () {

		mat.renderQueue = index;


	}

	public void MoveInHierarchy(int delta)
	{
		int index = transform.GetSiblingIndex();
		transform.SetSiblingIndex(index + delta);
	}

}
