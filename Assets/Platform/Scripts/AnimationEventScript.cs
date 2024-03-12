using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AnimationEventScript : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public Transform newTarget;
    public string sceneToLoad;

    public void ChangeCameraLookAt()
    {
        if (virtualCamera != null && newTarget != null)
        {
            virtualCamera.LookAt = newTarget;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
