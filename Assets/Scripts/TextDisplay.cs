using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public GameObject UiObject;

    // Start is called before the first frame update
    // The text is not being showed since the activation is set false
    void Start()
    {
        UiObject.SetActive(false);
    }

    /// <summary>
    /// When the player hits this collider the activation option is set true and the text shows on screen.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UiObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// The set active is changed to false and the text goes away.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        UiObject.SetActive(false);
    }
}
