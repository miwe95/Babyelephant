using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superjump : MonoBehaviour
{
  public CapsuleCollider collider;
  public MovementController player_movement;
  public GameObject player;
  // Start is called before the first frame update
  void Start()
  {
    collider = GetComponent<CapsuleCollider>();
    player = GameObject.Find("Benjamin Blümchen");
    player_movement = player.GetComponent<MovementController>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      player_movement.super_jump = true;
      gameObject.SetActive(false);
    }
  }
  void Update()
  {

  }
}
