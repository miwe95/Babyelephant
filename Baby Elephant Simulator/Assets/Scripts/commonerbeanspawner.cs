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

  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (spawnTimer >= spawnCooldown)
    {
      spawnTimer = 0;
      if (commonerCounter <= 10)
      {
        Instantiate(commonerPrefab, commonerSpawnpoint.position, commonerSpawnpoint.rotation);
        commonerCounter++;
      }
    }
    spawnTimer += Time.deltaTime;
  }
}
