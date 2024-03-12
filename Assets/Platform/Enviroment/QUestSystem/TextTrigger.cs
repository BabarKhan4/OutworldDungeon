using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
   public TextMeshProUGUI textToChange; // Reference to the TextMeshProUGUI element

    // Called when the player triggers this object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the trigger is for the player
        {
            if (textToChange != null)
            {
                // Change color from red to green
                textToChange.color = Color.green;

                // Replace text content
                if (textToChange.text == "1-Test Controls")
                {
                    textToChange.text = "1- Completed";
                }
                // Add more conditions for additional UI elements here if needed
            }
        }
    }
}
