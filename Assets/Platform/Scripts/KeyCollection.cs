using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCollection : MonoBehaviour
{
    public TextMeshProUGUI keyText; // Reference to the TextMeshProUGUI element displaying the key status
    public TextMeshProUGUI completionText; // Reference to the completion text element

    private bool hasKey = false; // Flag to track if the player has collected the key

    // Call this method when the player collects the key
    public void CollectKey()
    {
        hasKey = true;
        keyText.text = "Key: Collected";

        // Check if both key and coins are collected
        CheckCompletion();
    }

    // Method to check if both key and coins are collected
    private void CheckCompletion()
    {
        if (hasKey)
        {
            // Change the completion text and color when both key and coins are collected
            if (completionText != null)
            {
                completionText.color = Color.green;
                completionText.text = "3- Completed";
            }
        }
    }
}