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
        doorAnimator = transform.Find("TheDoor").GetComponent<Animator>();
    }

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
            if(Input.GetKeyDown(KeyCode.E))
            {
                PopUp.SetActive(false);
                doorAnimator.SetBool("open", true);
            }
        }
    }
}
