using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements; // UI elements to enable/disable

    public void DisableUI()
    {
        SetUIActiveState(false);
    }

    public void EnableUI()
    {
        SetUIActiveState(true);
    }

    private void SetUIActiveState(bool state)
    {
        foreach (GameObject uiElement in uiElements)
        {
            if(uiElement != null) // Add a null check for safety
                uiElement.SetActive(state);
        }
    }
}
