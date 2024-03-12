using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public float targetVolume = 1.0f;
    public float fadeInDuration = 2.0f; // Adjust duration as needed

    private float currentVolume = 0.0f;
    private bool isFadingIn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && audioSource != null && !isFadingIn)
        {
            isFadingIn = true;
            StartCoroutine(FadeInAudio());
            audioSource.Play(); // Start playing the audio
        }
    }

    IEnumerator FadeInAudio()
    {
        float timer = 0.0f;
        float startVolume = audioSource.volume;

        while (timer < fadeInDuration)
        {
            currentVolume = Mathf.Lerp(0, targetVolume, timer / fadeInDuration);
            audioSource.volume = currentVolume;
            timer += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
        isFadingIn = false;
    }
}