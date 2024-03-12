using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
  //  public string nextSceneName; // Name of the next scene to load
    public float transitionTime =1f;
    public Animator Transition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is the player
        {
          UnlockedLevel();
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    void UnlockedLevel()
    {
      if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
      {
        PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex +1);
       PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) +1);
       PlayerPrefs.Save();
          
      }
    }
}
