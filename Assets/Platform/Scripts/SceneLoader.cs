using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
     SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);   
    }
}
