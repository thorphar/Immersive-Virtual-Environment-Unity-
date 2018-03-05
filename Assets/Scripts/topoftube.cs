using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topoftube : MonoBehaviour {

    public Transform SpawnPoint;
    //public Rigidbody ClockSpawn;
    public Rigidbody ChairSpawn;

    public int NumberOfClocks = 0;
    public int NumberofChairs = 2;

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

        Rigidbody[] RigidFabChair = new Rigidbody[NumberofChairs]; // create array of Rigidbody objects 
        for (int i = 0; i < NumberofChairs; i++) // loop through to create the number of chairs required
        {
            RigidFabChair[i] = Instantiate(ChairSpawn, getNewPos(), SpawnPoint.rotation) as Rigidbody; // create a new instants of the ChairSpawn
            RigidFabChair[i].mass = Random.Range(0.5f, 2.0f); // Provide a random mass to the new object
            RigidFabChair[i].transform.rotation = Quaternion.Euler(Random.Range(-40, 40), Random.Range(-40, 40), Random.Range(-40, 40)); // adjust the rotation
        }
    }
}
