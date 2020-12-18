using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnding : MonoBehaviour
{

    public GameObject youDaWinner = null;

    // Activates the collider to end the game when the player enters the captive room
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           youDaWinner.SetActive(true);
            Debug.Log("Ready to go!");
        }
    }
}
