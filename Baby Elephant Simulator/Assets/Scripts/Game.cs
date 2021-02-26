using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
  // Start is called before the first frame update
  public Text corona_bean_counter_text;
  public Text points_counter_text;
  public int corona_bean_counter;
  public float point_counter;

  void Start()
  {
    corona_bean_counter = 1;
    point_counter = 0;
  }

  // Update is called once per frame
  void Update()
  {
    corona_bean_counter_text.text = "Corona Beans: " + corona_bean_counter.ToString();
    points_counter_text.text = "Points: " + point_counter.ToString();
    if (corona_bean_counter == 10)
      SceneManager.LoadScene("MainMenu");

    if (point_counter == 10)
    {
      Debug.Log("Win, TODO: ADD WIN SCENE");
    }
  }
}
