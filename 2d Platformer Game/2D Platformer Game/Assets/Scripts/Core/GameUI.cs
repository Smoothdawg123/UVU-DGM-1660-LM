using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
   //Play Game
    public void PlayGame()
    {
         SceneManager.LoadScene("Level 1");

    }

     //Main Menu    
    public void GoToMainMenu()
    {
         SceneManager.LoadScene("MainMenu");
    }
     //Restart
    public void Restart()
    {
         SceneManager.UnloadSceneAsync("Level 1");
          SceneManager.LoadSceneAsync("MainMenu");
    }


}
