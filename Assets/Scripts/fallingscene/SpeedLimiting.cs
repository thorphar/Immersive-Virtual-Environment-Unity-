using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpeedLimiting : MonoBehaviour {
    private float error = 0.0f;
    private float error_prev = 0.0f;
    private float integral = 0.0f;
    private float derivative = 0.0f;
    private float output = 0.0f;
    private float Kp = 0.2f;
    private float Ki = 0.9f;
    private float Kd = 0.0f;
    private float bias = 0.0f;
    private int desired = 12;

    private float lastoutput = 0.0f;


    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();

        error = desired - Mathf.Abs(rb.velocity.y);
        integral = integral + (error * Time.deltaTime);
        derivative = (error - error_prev) / Time.deltaTime;
        output = (Kp * error) + (Ki * integral) + (Kd * derivative) + bias;
        error_prev = error;
        lastoutput = output;


            rb.velocity = new Vector3(rb.velocity.x, -((lastoutput+output)/2), rb.velocity.z);
       

    /*
        string path = "Assets/modles/fallingobjects/speed.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(-output);
        writer.Close();
        */

    }
}
