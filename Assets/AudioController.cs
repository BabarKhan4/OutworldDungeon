using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource playerVoiceSource;

    private float originalMusicVolume;

    void Start()
    {
        // Store the original music volume
        originalMusicVolume = musicSource.volume;
    }

    void Update()
    {
        if (playerVoiceSource.isPlaying)
        {
            // Lower the music volume when the player's voice is playing
            musicSource.volume = originalMusicVolume * 0.5f; // Adjust the multiplier as needed
        }
        else
        {
            // Reset the music volume when the voice stops playing
            musicSource.volume = originalMusicVolume;
        }
    }
}
