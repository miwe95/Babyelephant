using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedMenu : MonoBehaviour
{
   // public string newGameScene;

   public void LoadNextLevel()
  {
    // SceneManager.LoadScene(newGameScene);
    SceneManager.LoadScene("SampleScene");
  }

  public void QuitGame()
  {
    Debug.Log("Quit Adventure!");
    Application.Quit();
  }
}
