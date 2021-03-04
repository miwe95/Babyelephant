using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedScreen : MonoBehaviour
{
  public void Quit()
  {
    Debug.Log("Application Quit");
    Application.Quit();
  }
  
  public void LoadNextLevel()
  {
    // SceneManager.LoadScene(newGameScene);
    SceneManager.LoadScene("SampleScene");
  }
}
