using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Platformer;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject[] objectsToDisable; // Add game objects to be disabled during pause

    public GameObject pauseMenu; // Reference to your canvas panel with the pause menu
    public Button resumeButton; // Reference to the resume button on the canvas panel
    public Button exitButton; // Reference to the exit button on the canvas panel
    public Button mainMenuButton; // Reference to the main menu button on the canvas panel

    private bool isPaused = false;

    private void Start()
    {
        // Ensure the pause menu is initially inactive
        pauseMenu.SetActive(false);
        // Add a listener to the resume button
        resumeButton.onClick.AddListener(ResumeGame);

        // Add a listener to the exit button
        exitButton.onClick.AddListener(ExitGame);
        // Add a listener to the main menu button
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void Update()
    {
        // Check for the input to pause/resume the game (you can change this to your preferred input)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop the in-game time

        // Disable the objects that should be paused
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        // Show the pause menu
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the in-game time

        // Enable the objects that were paused
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }

        // Hide the pause menu
        pauseMenu.SetActive(false);
    }
        public void ExitGame()
    {
        Debug.Log("Exiting game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
        public void LoadMainMenu()
    {
        // Load the Main_Menu scene
        SceneManager.LoadScene("Main_Menu");
    }
}
