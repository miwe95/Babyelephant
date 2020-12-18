using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenueScene;
    public GameObject pauseMenu;
    public bool isPaused;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
         if (isPaused)
         {
           ResumeGame();
         }
         else
         {
           isPaused = true;
           pauseMenu.SetActiveRecursively(true);
           Time.timeScale = 0f;
         }
      }
    }

    public void ResumeGame()
    {
      isPaused = false;
      pauseMenu.SetActiveRecursively(false);
      Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
       Time.timeScale = 1f;
       // SceneManager.LoadScene(mainMenueScene);
       SceneManager.LoadScene("mainMenu");
    }
}
