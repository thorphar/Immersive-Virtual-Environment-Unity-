using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingnoise : MonoBehaviour {
	private Vector3 lastPos;
	private float totalDist = 0f;
	public float stepDist = 0.5f;
	private AudioSource playerAudio;
	public AudioClip walkClip;
	public float volume = 1f;


	// Use this for initialization
	void Start () {

		lastPos = gameObject.transform.position;

		playerAudio = gameObject.GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 nowPos = gameObject.transform.position;

		Vector3 deltaPos = nowPos - lastPos ;

		totalDist += Mathf.Sqrt (Mathf.Pow (Mathf.Abs(deltaPos.x), 2) + Mathf.Pow (Mathf.Abs(deltaPos.z), 2));

		Debug.Log (nowPos + "   " + deltaPos + "   " + totalDist);

		if (totalDist > stepDist) {
			totalDist = 0;
			playerAudio.PlayOneShot (walkClip, volume);
		}

		lastPos = gameObject.transform.position;
	}
}
