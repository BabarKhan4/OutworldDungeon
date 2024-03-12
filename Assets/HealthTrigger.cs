using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
      [SerializeField] private string playerTag = "Player";
    [SerializeField] private LayerMask enemyLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            RestartLevel();
        }
        else if (IsEnemy(other.gameObject))
        {
            Destroy(other.gameObject);
        }
    }

    private bool IsEnemy(GameObject gameObject)
    {
        return ((1 << gameObject.layer) & enemyLayer) != 0;
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}