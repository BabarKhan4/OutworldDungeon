using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Point A position
    public Transform pointB; // Point B position
    public float speed = 2.0f; // Speed of movement

    private Vector3 targetPosition; // The current target position

    void Start()
    {
        targetPosition = pointB.position; // Start by moving towards point B
    }

    void Update()
    {
        // Move the platform towards the target position using Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // If the platform reaches the target position, switch the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pointA.position)
                targetPosition = pointB.position;
            else
                targetPosition = pointA.position;
        }
    }
}
