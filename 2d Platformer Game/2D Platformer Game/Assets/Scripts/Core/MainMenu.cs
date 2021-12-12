using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //On button press play game
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");

    }

    // On button Quit Game
    public void QuitGame()
    {
        Application.Quit();

    }
   
}
