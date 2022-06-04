using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button buttonNewGame;
    private Button buttonContinueGame;
    private Button buttonQuit;
    private Button button3;


    // Start is called before the first frame update
    void Start()
    {
        buttonNewGame = GameObject.Find("StartGame").GetComponent<Button>();
        buttonNewGame.onClick.AddListener(() => StartGame());

        buttonContinueGame = GameObject.Find("ContinueGame").GetComponent<Button>();
        buttonContinueGame.onClick.AddListener(() => ContinueGame());

        buttonQuit = GameObject.Find("QuitGame").GetComponent<Button>();
        buttonQuit.onClick.AddListener(() => QuitGame());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// loads the first scene, deletes saved values
    /// </summary>
    public void StartGame()
    {
        Debug.Log("new game button");



        SaveNReload.EraseSave();
        SceneManager.LoadScene("Home");
    }

    /// <summary>
    /// loads the last scene saved as well as other values
    /// </summary>
    public void ContinueGame()
    {
        Debug.Log("Continue game button");

        string level = SaveNReload.LoadLevel();

        if (level != "nothing")
        {
            SceneManager.LoadScene(level);
        }
        

    }



    /// <summary>
    /// quits game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("quit button");
        Application.Quit();
    }
    

}
