using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName; // Name of the animation parameter in the Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if an Animator is assigned and the animation name is not empty
            if (animator != null && !string.IsNullOrEmpty(animationName))
            {
                // Enable the animator and play the specified animation
                animator.enabled = true;
                animator.Play(animationName);
            }
        }
    }
}
