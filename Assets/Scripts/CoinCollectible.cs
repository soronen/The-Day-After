using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    /// <summary>
    /// collects coins, adds them to player, and destroys them. Triggered by collision
    /// </summary>
    /// <param name="other">foreign collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlScript player = other.GetComponent<PlayerControlScript>();

        if (player != null)
        {
            player.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
