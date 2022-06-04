using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene;
    float timer = 1;

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerControlScript controller = other.GetComponent<PlayerControlScript>();
        
        if (controller != null)
        {
            Debug.Log("Player entered scene change zone");

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log("Time left: " + timer);
            }
            else
            {
             
                SaveNReload.SaveLevel(nextScene);

                LoadLevel(nextScene);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Timer reset");
        timer = 2; 
    }


    public void LoadLevel(string scene)
    {
        Debug.Log("scene loaded");
        SceneManager.LoadScene(scene);
    }


}
