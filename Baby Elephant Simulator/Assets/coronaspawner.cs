﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coronaspawner : MonoBehaviour
{


  public GameObject coronaPrefab;
  public Transform coronaSpawnpoint;
  private Game game;

  void Start()
  {
    game.corona_bean_counter++;
    Instantiate(coronaPrefab, coronaSpawnpoint.position, coronaSpawnpoint.rotation);
  }



}