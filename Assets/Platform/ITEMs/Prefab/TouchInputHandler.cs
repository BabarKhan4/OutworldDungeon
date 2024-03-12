using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class TouchInputHandler : MonoBehaviour
{
     private ConversationManager conversationManager;

    private void Start()
    {
        // Find the ConversationManager script on the same GameObject
        conversationManager = GetComponent<ConversationManager>();

        if (conversationManager == null)
        {
            Debug.LogError("ConversationManager script not found on the same GameObject!");
            enabled = false; // Disable this script if ConversationManager is not found
        }
    }

    private void Update()
    {
        // Handle touch input to interact with the ConversationManager
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (conversationManager != null)
            {
                conversationManager.PressSelectedOption();
            }
        }
        // Add other touch input interactions as needed...
    }
}
