using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    private GameObject Healthbar;
    public static GameUI instance;


    void Awake()
    {
        //Set the instance to this script
        instance = this; 
    }

    public GameObject WinScreen;
    public void PlayAgain()
    {
         SceneManager.LoadScene("Level 1");

    }

    public void GoToMainMenu()
    {
         SceneManager.LoadScene("MainMenu");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("WinScreen");
    }

}
