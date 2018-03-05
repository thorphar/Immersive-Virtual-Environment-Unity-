using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endoftube : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FallingObject") {
            Destroy(other);
        }
        other.transform.position = new Vector3(-8.46f, 11.78f, -2.5f);
    }

}
