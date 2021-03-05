using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
  // HEALTH
  public int maxHealth = 10;
  public int currentHealth;
  public HealthBar healthBar;

  // BEANS
  public int maxBean = 10;
  public int currentBean;
  public BeansBar beanBar;

  // POINTS
  public int maxPoint = 10;
  public int currentPoint;
  public PointsBar pointBar;

  // Start is called before the first frame update

  /*
  public Text corona_bean_counter_text;
  public Text points_counter_text;
  //public int corona_bean_counter;
  public float point_counter;
  */


  void Start()
  {
    // HEALTH
    currentHealth = maxHealth;
    healthBar.setMaxHealth(maxHealth);

    // BEANS
    currentBean = 0;
    beanBar.setMaxBean(maxBean);

    // POINTS
    currentPoint = 0;
    pointBar.setMaxPoint(10);
    pointBar.setPoint(currentPoint);
    /*  
  corona_bean_counter = 1;
  point_counter = 0;
  */
  }

  // Update is called once per frame
  void Update()
  {
    // HEALTH
    if (currentHealth <= 0)
    {
      SceneManager.LoadScene("GameOverScreen");
    }
    // BEANS
    if (currentBean == 10)
      SceneManager.LoadScene("GameOverScreen");

    // POINTS
    if (currentPoint == 10)
      SceneManager.LoadScene("LevelFinishedScreen");

    /*
    corona_bean_counter_text.text = "Corona Beans: " + corona_bean_counter.ToString();
    points_counter_text.text = "Points: " + point_counter.ToString();
    
    if (corona_bean_counter == 10)
      SceneManager.LoadScene("GameOverScreen");

    if (point_counter == 10)
      Debug.Log("Win, TODO: ADD WIN SCENE");
      */

  }


  // HEALTH
  public void TakeHealth(int health)
  {
    currentHealth -= health;
    healthBar.setHealth(currentHealth);
  }

  // BEANS
  public void TakeBean(int bean)
  {
    currentBean -= bean;
    beanBar.setBean(currentBean);
  }
  public void GiveBean(int bean)
  {
    currentBean += bean;
    beanBar.setBean(currentBean);
  }

  // POINTS
  public void TakePoint(int point)
  {
    currentPoint -= point;
    pointBar.setPoint(currentPoint);
  }

  public void GivePoint(int point)
  {
    currentPoint += point;
    pointBar.setPoint(currentPoint);
  }


}
