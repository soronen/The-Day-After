using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string itemType;

    /// <summary>
    /// If player touches the object, destroys it and calls the AddToInventory method from Userinterface.
    /// </summary>
    /// <param name="other">foreign collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControlScript controller = other.GetComponent<PlayerControlScript>();

        if (controller != null)
        {
            Userinterface.instance.AddToInventory(itemType);
            Destroy(gameObject);

        }
    }

    /// <summary>
    /// Destroyes in in game objects if they are all already collected into the UI.
    /// </summary>
    private void Start()
    {
        if (SaveNReload.LoadItems(itemType) == itemType)
        {
            Destroy(gameObject);
        }
    }
}