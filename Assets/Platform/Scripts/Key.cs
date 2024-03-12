using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyCollection keyCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the CollectKey method from the KeyCollection script
            keyCollection.CollectKey();
            // Deactivate the key object when collected
            gameObject.SetActive(false);
        }
    }
}