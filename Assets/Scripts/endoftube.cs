using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endoftube : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallingObject") {
			Destroy(other.gameObject);
        }
        other.transform.position = new Vector3(-8.46f, 50f, -2.5f);
    }

}
