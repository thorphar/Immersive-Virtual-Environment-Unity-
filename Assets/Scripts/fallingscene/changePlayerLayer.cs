using UnityEngine;
using System.Collections;

public class changePlayerLayer : MonoBehaviour
{

    public int WhenEnteringtheHoleLayer; // Player is in the hole
    public int WhenStandingAroundLayer;  // Player is on the top of the table

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // If the player collides with the top of the tube the layer must be changed
        {
            other.gameObject.layer = WhenEnteringtheHoleLayer;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") // Once the object has left the collider change the layer again so the player can stand on the map
        {
            other.gameObject.layer = WhenStandingAroundLayer;
        }
    }
}