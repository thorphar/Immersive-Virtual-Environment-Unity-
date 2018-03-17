using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topoftube : MonoBehaviour {

    public Transform SpawnPoint;
    public Rigidbody[] SpawnObjects;

    public int Numberofobjects = 2;

    private Vector3 getNewPos() { //  used to create a random spawn pos with range of 2.5 +- 
        Vector3 SpawnPos = new Vector3(SpawnPoint.position.x + Random.Range(-2.5f, 2.5f), SpawnPoint.position.y + 20 +  Random.Range(-20.0f,20.0f),
            SpawnPoint.position.z + Random.Range(-2.5f, 2.5f));
        return SpawnPos;
    }


    private void OnTriggerEnter(Collider other)
    {

        // Player has entered the top of the tube
        // start to place falling objects

        /*
        Rigidbody[] RigidFabClock = new Rigidbody[NumberOfClocks];
        for (int i = 0; i < NumberOfClocks; i++) {
            RigidFabClock[i] = Instantiate(ClockSpawn, getNewPos(), SpawnPoint.rotation) as Rigidbody;
            RigidFabClock[i].mass = Random.Range(0.5f, 2.0f);
            RigidFabClock[i].transform.rotation = Quaternion.Euler(Random.Range(-40,40), Random.Range(-40, 40), Random.Range(-40, 40));
        }*/
		if (other.tag == "Player") {
			for (int y = 0; y < SpawnObjects.Length; y++) {
				Rigidbody[] RigidFab = new Rigidbody[Numberofobjects]; // create array of Rigidbody objects 
				for (int i = 0; i < Numberofobjects; i++) { // loop through to create the number of chairs required
					RigidFab [i] = Instantiate (SpawnObjects[y], getNewPos (), SpawnPoint.rotation) as Rigidbody; // create a new instants of the ChairSpawn
					RigidFab [i].mass = Random.Range (0.5f, 2.0f); // Provide a random mass to the new object
					RigidFab [i].transform.rotation = Quaternion.Euler (Random.Range (-40, 40), Random.Range (-40, 40), Random.Range (-40, 40)); // adjust the rotation
					RigidFab [i].useGravity = false;
				}
			}
		}
    }
}
