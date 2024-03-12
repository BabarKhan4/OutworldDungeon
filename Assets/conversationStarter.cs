using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using Platformer;
using UnityEngine;

public class conversationStarter : MonoBehaviour
{
     [SerializeField] private NPCConversation myConversation;
    [SerializeField] private PlayerController playerController; // Reference to the PlayerController script

    private void Start()
    {
        // Subscribe to the OnConversationEnd event from ConversationManager
        ConversationManager.Instance.OnConversationEnd.AddListener(EnablePlayerController);
    }
        private void EnablePlayerController()
    {
        // Re-enable the PlayerController script
        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the conversation
            ConversationManager.Instance.StartConversation(myConversation);

            // Disable the PlayerController script while in conversation
            if (playerController != null)
            {
                playerController.enabled = false;
            }
        }
    }

}
