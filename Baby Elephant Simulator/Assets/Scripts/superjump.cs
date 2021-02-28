using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superjump : MonoBehaviour
{
  public CapsuleCollider collider;
  public MovementController player_movement;
  public GameObject player;
  public Material m;
  GameObject elephant_material;
  // Start is called before the first frame update
  void Start()
  {
    collider = GetComponent<CapsuleCollider>();
    player = GameObject.Find("Benjamin Blümchen");
    player_movement = player.GetComponent<MovementController>();
    elephant_material = GameObject.Find("Elephant");
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      player_movement.super_jump = true;
      m = elephant_material.GetComponent<SkinnedMeshRenderer>().material;
      m.color = Color.yellow;

      gameObject.SetActive(false);
    }
  }
  void Update()
  {

  }
}
