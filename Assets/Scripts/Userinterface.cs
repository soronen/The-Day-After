using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Userinterface : MonoBehaviour
{
    public static Userinterface instance { get; private set; }

    private int health;
    private int numofHearts;

    public Image[] hearts;
    public Sprite greyhart;
    public Sprite redheart;

    private Text coinCount;
    private Button restartButton;
    GameObject youDied;

    GameObject keyItem;
    GameObject idItem;
    GameObject phoneItem;
    GameObject walletItem;

    // finds the compoments used and creates an instance of HUD
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinCount = GameObject.Find("CoinCount").GetComponent<Text>();

        keyItem = GameObject.Find("key ui");
        
        if (SaveNReload.LoadItems("key") == "nothing")
        {
            keyItem.SetActive(false);
        }
        

        walletItem = GameObject.Find("wallet ui");
        if (SaveNReload.LoadItems("wallet") == "nothing")
        {
            walletItem.SetActive(false);
        }

        idItem = GameObject.Find("id ui");
        if (SaveNReload.LoadItems("id") == "nothing")
        {
            idItem.SetActive(false);
        }

        phoneItem = GameObject.Find("phone ui");
        if (SaveNReload.LoadItems("phone") == "nothing")
        {
            phoneItem.SetActive(false);
        }



        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(() => ButtonClicked(restartButton));
        youDied = GameObject.Find("YouDied");
        youDied.SetActive(false);

    }

    /// <summary>
    /// sets the number of heart containers, as well as greys out hearts when losing hp
    /// 
    /// <param name="health">current health value</param>
    /// </summary>
    public void SetHealth(float health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = redheart;
            }
            else
            {
                hearts[i].sprite = greyhart;
            }

            if (i < numofHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    /// <summary>
    /// Sets the max health (number of health containers) of the player character
    /// </summary>
    /// <param name="heartContainers">number of heartcontainers</param>
    public void SetMaxHealth(int heartContainers)
    {
        numofHearts = heartContainers;
    }

    /// <summary>
    /// Sets the value number of coins to be displayed on hud
    /// </summary>
    /// <param name="value">number of coins to be displayed</param>
    public void SetCoins(int value)
    {
        coinCount.text = value.ToString();
    }
    /// <summary>
    /// Activates the YouDied and its children in canvas
    /// </summary>
    public void Die()
    {
        youDied.SetActive(true);
    }

    /// <summary>
    /// Restart Button clicked reloads the active scene, and resets hp to 3. 
    /// </summary>
    /// <param name="b">pressed button</param>
    private void ButtonClicked(Button b)
    {
        Debug.Log("button clicked: " + b);

        if (b == restartButton)
        {
            
            Scene scene = SceneManager.GetActiveScene();
            SaveNReload.SaveHealth(3);
            SceneManager.LoadScene(scene.name);
            GameObject.Find("YouDied").SetActive(false);
           
        }

    }

    /// <summary>
    /// Activates the UI element corresponding to the picket item, as well as calls a SaveInventory 
    /// </summary>
    /// <param name="itemName">item picked</param>
    public void AddToInventory(string itemName)
    {
        Debug.Log("item added to inventory: " + itemName);

        if (itemName == "key")
        {
            keyItem.SetActive(true);
        }
        else if (itemName == "wallet")
        {
            walletItem.SetActive(true);
        }
        else if (itemName == "phone")
        {
            phoneItem.SetActive(true);
        }
        else if (itemName == "id")
        {
            idItem.SetActive(true);
            SaveNReload.SaveItems(itemName);
        }

        SaveNReload.SaveItems(itemName);
    }



}