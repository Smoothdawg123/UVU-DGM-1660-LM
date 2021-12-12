using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);

    }
    //On Cancel button pause game
    void Update()
    {
           if(Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }
      
    }
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    //On Cancel or button press resume game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    //On button press go to main menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }


   
}
