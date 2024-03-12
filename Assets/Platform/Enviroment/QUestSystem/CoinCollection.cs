using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Reference to the TextMeshProUGUI element displaying coins count
    public TextMeshProUGUI completionText; // Reference to the completion text element

    private int totalCoins = 18; // Total number of coins in the scene
    private int collectedCoins = 0; // Counter for collected coins
    private bool allCoinsCollected = false; // Flag to track if all coins are collected

    // Call this method when a coin is collected
    public void CollectCoin()
    {
        collectedCoins++;
        coinText.text = "Coins: " + collectedCoins.ToString(); // Update UI displaying collected coins count with parentheses

        // Check if all coins are collected
        if (collectedCoins >= totalCoins && !allCoinsCollected)
        {
            allCoinsCollected = true;

            // Change the completion text and color when all coins are collected
            if (completionText != null)
            {
                completionText.color = Color.green;
                completionText.text = "2- Completed";
            }
        }
    }
}
