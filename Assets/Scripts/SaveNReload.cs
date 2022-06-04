using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveNReload : MonoBehaviour
{

    public List<string> savedItems = new List<string>();


    /// <summary>
    /// If SharedPrefs contains value for current health, return it. Otherwise return 3 (= full hp)
    /// </summary>
    /// <returns>int current health</returns>
    public static int LoadHealth()
    {
        if (PlayerPrefs.HasKey("savedHealth"))
        {
            return PlayerPrefs.GetInt("savedHealth");
        }
        else
        {
            return 3;
        }
    }

    /// <summary>
    /// Saves the current health value
    /// </summary>
    /// <param name="value">int value to save</param>
    public static void SaveHealth(int value)
    {
        PlayerPrefs.SetInt("savedHealth", value);
    }

    /// <summary>
    /// Loads saved number of coins, if no value is saved returns 0.
    /// </summary>
    /// <returns>number of coins or 0 if no value saved</returns>
    public static int LoadCoins()
    {
        if (PlayerPrefs.HasKey("savedCoins"))
        {
            return PlayerPrefs.GetInt("savedCoins");
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// saves coins
    /// </summary>
    /// <param name="value">int value to save</param>
    public static void SaveCoins(int value)
    {
        PlayerPrefs.SetInt("savedCoins", value);
    }


    /// <summary>
    /// saves the level to sharedPrefs.
    /// </summary>
    /// <param name="level">level name in string</param>
    public static void SaveLevel(string level)
    {
        PlayerPrefs.SetString("savedLevel", level);
    }


    /// <summary>
    /// returns the level saved to sharedprefs, if no value is saved return string "nothing"
    /// </summary>
    /// <returns>level name in string or "nothing" if there is no level saves</returns>
    public static string LoadLevel()
    {
        if (PlayerPrefs.HasKey("savedLevel"))
        {
            return PlayerPrefs.GetString("savedLevel");
        }
        else
        {
            return "nothing";
        }
    }


    /// <summary>
    /// clears sharedPreferenses
    /// </summary>
    public static void EraseSave()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Saves erased");
    }


    /// <summary>
    /// Saves the item name to SharedPreferenses
    /// </summary>
    /// <param name="itemName">values to be saved (key and value are the same) </param>
    public static void SaveItems(string itemName)
    {
        PlayerPrefs.SetString(itemName, itemName);
    }


    /// <summary>
    /// Loads itemName from sharedPrefs, if no value saved return string "nothing"
    /// </summary>
    /// <param name="itemName">string which is used to getString from sharedprefs</param>
    /// <returns>either the value from the key value pair or "nothing", if nothing is saved</returns>
    public static string LoadItems(string itemName)
    {
        if (PlayerPrefs.HasKey(itemName))
        {
            return PlayerPrefs.GetString(itemName);
        }
        else
        {
            return "nothing";
        }
    }
}
