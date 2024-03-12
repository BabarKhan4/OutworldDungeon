using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipSceneButton : MonoBehaviour
{
    public void OnSkipButtonClicked()
    {
        // Load the next scene based on the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
         SceneManager.LoadScene("Main_Menu");;
    }
}
