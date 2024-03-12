using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmosRenderer : MonoBehaviour
{
    public Transform player;
    public float cubeSize = 5f;
    public LayerMask affectedLayers; // Define which layers are affected

    private void Update()
    {
        // Iterate through all the objects with Renderer components in the scene
        Renderer[] renderersInScene = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderersInScene)
        {
            // Check if the object's layer is in the affectedLayers
            if (((1 << renderer.gameObject.layer) & affectedLayers) != 0)
            {
                // Calculate the distance between the object and the player
                float distance = Vector3.Distance(renderer.transform.position, player.position);

                // Check if the object is within the cube area
                if (distance <= cubeSize)
                {
                    // Enable rendering for objects within the cube
                    renderer.enabled = true;
                }
                else
                {
                    // Disable rendering for objects outside the cube
                    renderer.enabled = false;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a wireframe cube gizmo around the player to represent the cube area
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(player.position, new Vector3(cubeSize * 2, cubeSize * 2, cubeSize * 2));
    }
}
