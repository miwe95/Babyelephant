using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commonerbeanspawner : MonoBehaviour
{
  private float spawnTimer = 0f;
  private float spawnCooldown = 5f;
  public float commonerCounter = 0f;
  public GameObject commonerPrefab;
  public Transform commonerSpawnpoint;
  private float spawnChance = 0f;
  
  void Update()
  {
    
    spawnChance = Random.Range(0, 100);
    
    if ((spawnTimer >= spawnCooldown) && (spawnChance > 50))
    {
      spawnTimer = 0;
      if (commonerCounter <= 10)
      {
        Instantiate(commonerPrefab, commonerSpawnpoint.position, commonerSpawnpoint.rotation);
        commonerCounter++;
      }
    }
    else if ((spawnTimer >= spawnCooldown) && (spawnChance <= 50))
    {
      spawnTimer = 0;
    }

    spawnTimer += Time.deltaTime;
  }
}
