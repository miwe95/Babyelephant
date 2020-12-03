using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
  CharacterController controller;
  public float rotationSpeed, movementSpeed, gravity = 20;
  Vector3 movementVector = Vector3.zero;
  private float desiredRotationAngle = 0;
  Animator animator;

  private void Start()
  {
    controller = GetComponent<CharacterController>();
    animator = GetComponent<Animator>();
  }

  private float setCorrectAnimation()
  {
    float currentAnimationSpeed = animator.GetFloat("move");
    if (desiredRotationAngle > 10 || desiredRotationAngle < -10)
    {
      if (currentAnimationSpeed < 0.2f)
      {
        currentAnimationSpeed += Time.deltaTime * 2;
        currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, 0, 0.2f);
      }
      animator.SetFloat("move", currentAnimationSpeed);
    }
    else
    {
      if (currentAnimationSpeed < 1)
      {
        currentAnimationSpeed += Time.deltaTime * 2;
      }
      else
      {
        currentAnimationSpeed = 1;
      }
      animator.SetFloat("move", currentAnimationSpeed);
    }
    return currentAnimationSpeed;
  }

  public void HandleMovement(Vector2 input)
  {
    if (controller.isGrounded)
    {
      if (input.y > 0)
      {
        movementVector = transform.forward * movementSpeed;
      }
      else
      {
        movementVector = Vector3.zero;
        animator.SetFloat("move", 0);
      }
    }
  }

  public void HandleMovementDirection(Vector3 direction)
  {
    desiredRotationAngle = Vector3.Angle(transform.forward, direction);
    var crossProduct = Vector3.Cross(transform.forward, direction).y;
    if (crossProduct < 0)
      desiredRotationAngle *= -1;
  }

  private void RotatePlayer()
  {
    if (desiredRotationAngle > 10 || desiredRotationAngle < -10)
    {
      transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
    }
  }

  private void Update()
  {
    if (controller.isGrounded) // only rotate on ground
    {
      if (movementVector.magnitude > 0)
      {
        var animationSpeedMultiplier = setCorrectAnimation();
        RotatePlayer();
        movementVector *= animationSpeedMultiplier;
      }
    }
    movementVector.y -= gravity;
    controller.Move(movementVector * Time.deltaTime);
  }
}