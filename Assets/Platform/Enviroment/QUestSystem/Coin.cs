using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public CoinCollection coinCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            // Call the CollectCoin method from the CoinCollection script
            coinCollection.CollectCoin();
            // Deactivate the coin object when collected
            gameObject.SetActive(false);
        }
    }
}
