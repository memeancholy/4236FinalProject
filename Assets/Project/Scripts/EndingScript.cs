using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public static bool GameEnded = false;

    public GameObject endMenuUI;
    public GameObject mouseLook;

    // Stops gameplay and brings up the end menu when the player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You won!");
            EndMenu();
        }
    }

    public void EndMenu()
    {
        // Freezes gameplay, locks the camera and allows the mouse to click different options
        endMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameEnded = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.GetComponent<TestScript>().enabled = false;
        AudioListener.volume = 0;
    }

    // Returns to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
