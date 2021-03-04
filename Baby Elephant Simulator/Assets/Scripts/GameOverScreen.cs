using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  public void quit()
  {
    Debug.Log("Application Quit");
    Application.Quit();
  }
  
  public void retry()
  {
    SceneManager.LoadScene("CityScene");
  }
}
