﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // Starts the game from the main menu
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the application and prints it to the console
    public void QuitGame ()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
