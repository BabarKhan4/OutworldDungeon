using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float levelTimeInSeconds = 180f; // 3 minutes
    public TMP_Text timerText;
    public Transform finishPoint;
    [SerializeField] private string gameOverSceneName = "GameOverScene"; // Assign the scene name in the Inspector
    public Image circularTimer; // Reference to the Image component representing the circular timer

    private float currentTime;
    private bool isGameOver = false;
    public GameObject[] enemies; // Array to store enemies from the Inspector

    private void Start()
    {
        currentTime = levelTimeInSeconds;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                GameOver();
            }

            UpdateTimerDisplay();
            UpdateCircularTimerFill(); // Update the circular timer fill
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateCircularTimerFill()
    {
        if (circularTimer != null)
        {
            float fillAmount = currentTime / levelTimeInSeconds;
            circularTimer.fillAmount = fillAmount;
        }
    }


    public void EnemyDefeated(GameObject enemy)
    {
        // Enemy is defeated, remove from the array and add time
        if (ArrayContainsEnemy(enemy))
        {
            RemoveEnemyFromArray(enemy);
            currentTime += 5f; // Add 5 seconds
            UpdateTimerDisplay();
        }
    }

    private bool ArrayContainsEnemy(GameObject enemy)
    {
        foreach (GameObject e in enemies)
        {
            if (e == enemy)
            {
                return true;
            }
        }
        return false;
    }

    private void RemoveEnemyFromArray(GameObject enemy)
    {
        List<GameObject> updatedEnemies = new List<GameObject>(enemies);
        updatedEnemies.Remove(enemy);
        enemies = updatedEnemies.ToArray();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.transform.position == finishPoint.position)
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        // You've reached the FinishPoint
        // Perform actions for completing the level (e.g., load next level)
        Debug.Log("Level completed!");
        // Load the next level or perform other actions here
    }

    private void GameOver()
    {
        // Player did not reach the FinishPoint in time
        // Perform actions for game over (e.g., load game over scene)
        Debug.Log("Game over!");
        isGameOver = true;
        // Load the game over scene or perform other actions here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Load the specified game over scene
    }
}