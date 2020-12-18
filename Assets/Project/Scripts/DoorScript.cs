using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator doorAnimator;
    public GameObject PopUp = null;

    // Start is called before the first frame update
    void Start()
    {
        // Gets animator component used to open/close the door
        doorAnimator = transform.Find("TheDoor").GetComponent<Animator>();
    }

    // Enables the pop-up to open the door
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PopUp.SetActive(true);
            Debug.Log("Open the door!");
        }

        if(other.tag == "Enemy")
        {
            PopUp.SetActive(false);
            doorAnimator.SetBool("open", true);
        }
    }

    // Disables the pop-up to open the door, and closes the door
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorAnimator.SetBool("open", false);
            PopUp.SetActive(false);
        }

        if (other.tag == "Enemy")
        {
            doorAnimator.SetBool("open", false);
            PopUp.SetActive(false);
        }
    }

    // Checks if the pop-up is active
    private bool IsPopUpActive
    {
        get
        {
            return PopUp.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPopUpActive)
        {
            // If 'E' is pressed, the door will open
            if(Input.GetKeyDown(KeyCode.E))
            {
                PopUp.SetActive(false);
                doorAnimator.SetBool("open", true);
            }
        }
    }
}
