using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    /// <summary>
    /// adds 1 health if there are enough containers
    /// </summary>
    /// <param name="other">foreign collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlScript controller = other.GetComponent<PlayerControlScript>();

        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}