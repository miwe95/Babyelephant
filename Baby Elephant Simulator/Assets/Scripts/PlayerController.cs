using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  IInput input;
  PlayerMovementScript movement;

  void OnEnable()
  {
    input = GetComponent<IInput>();
    movement = GetComponent<PlayerMovementScript>();
    input.OnMovementDirectionInput += movement.HandleMovementDirection;
    input.OnMovementInput += movement.HandleMovement;
  }

  void OnDisable()
  {
    input.OnMovementDirectionInput -= movement.HandleMovementDirection;
    input.OnMovementInput -= movement.HandleMovement;
  }
}
