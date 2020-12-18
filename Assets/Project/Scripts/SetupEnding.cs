using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnding : MonoBehaviour
{

    public GameObject youDaWinner = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           youDaWinner.SetActive(true);
            Debug.Log("Ready to go!");
        }
    }
}
