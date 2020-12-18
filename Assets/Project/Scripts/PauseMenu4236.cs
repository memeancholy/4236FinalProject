using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu4236 : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject mouseLook;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;       
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.GetComponent<TestScript>().enabled = true;
        AudioListener.volume = 1;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mouseLook.GetComponent<TestScript>().enabled = false;
        AudioListener.volume = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
