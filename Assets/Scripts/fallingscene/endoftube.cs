using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endoftube : MonoBehaviour {
    public GameObject[] cutouthidingobjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Once the object has left the collider change the layer again so the player can stand on the map
        {
            other.gameObject.layer = 0;
            other.transform.position = new Vector3(-8.46f, 50f, -2.5f);
        }
        if (other.tag == "FallingObject") {
			Destroy(other.gameObject);
        }
        //hide the culling hole as it looks odd when looking up.
        for (int i = 0; i < cutouthidingobjects.Length; i++)
        {
            cutouthidingobjects[i].SetActive(true);
        }
       
    }

}
