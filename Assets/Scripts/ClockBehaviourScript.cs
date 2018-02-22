using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockBehaviourScript : MonoBehaviour {
	public GameObject secondHand;
	public GameObject minuteHand;
	public GameObject hourHand;

	float seconds;
	float minutes;
	float hours;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		seconds = DateTime.Now.Second;
		minutes = DateTime.Now.Minute + seconds / 60f;
		hours = DateTime.Now.Hour + minutes/60f;

		if (hours > 12) hours -= 12;

		float secondsRotation = 360 - ((360f / 60f) * seconds);
		float minutesRotation = 360 - ((360f / 60f) * minutes);
		float hoursRotation = 360 - ((360f / 12f) * hours);

		secondHand.transform.localEulerAngles = new Vector3(secondsRotation, 0, 0);
		minuteHand.transform.localEulerAngles = new Vector3(minutesRotation, 0, 0);
		hourHand.transform.localEulerAngles = new Vector3(hoursRotation, 0, 0);
	}
}
