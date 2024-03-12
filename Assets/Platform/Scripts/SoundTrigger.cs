using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundClip; // Sound clip to play

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // If there's no AudioSource attached, add one dynamically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Check if the sound clip is assigned
            if (soundClip != null)
            {
                // Play the sound
                audioSource.PlayOneShot(soundClip);
            }
            else
            {
                Debug.LogWarning("SoundClip not assigned.");
            }
        }
    }
}
