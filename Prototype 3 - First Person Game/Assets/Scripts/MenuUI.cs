using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    //On button press play game
  public void OnPlayButton()
  {
      SceneManager.LoadScene("Game");
  }
// on button press quit game
  public void OnQuitButton()
  {
      Application.Quit();
  }
}
