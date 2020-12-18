﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  // public string newGameScene;

  public void PlayGame()
  {
    // SceneManager.LoadScene(newGameScene);
    SceneManager.LoadScene("fy_PoolParty");
  }

  public void QuitGame()
  {
    Debug.Log("Quit Adventure!");
    Application.Quit();
  }
}
