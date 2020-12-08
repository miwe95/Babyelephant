using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
  private float InputX, InputZ, Speed, Gravity = 0;
  private Camera cam;
  private CharacterController characterController;
  private Animator animator;
  private Vector3 desiredMoveDirection;

  [SerializeField] float rotationSpeed = 0.1f;
  [SerializeField] float allowRotation = 0.1f;
  [SerializeField] float movementSpeed = 10f;
  [SerializeField] float gravityMultiplyer = 0.5f;
  [SerializeField] float jumpHeight = 5f;
  [SerializeField] float run_speed = 1f;
  private Vector3 moveDirection;
  private float gravityValue = -30.81f;
  private Vector3 playerVelocity;

  // Start is called before the first frame update
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    cam = Camera.main;
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    InputX = Input.GetAxis("Horizontal");
    InputZ = Input.GetAxis("Vertical");


    DesiredMoveDirection();
    InputDecider();
    MovementManager();
  }

  void InputDecider()
  {
    Speed = new Vector2(InputX, InputZ).sqrMagnitude;

    if (Input.GetKey(KeyCode.LeftShift) && Speed > allowRotation)
    {
      run_speed = 2;
      animator.SetFloat("move", 1f);
      RotationManager();
    }
    else if (Speed > allowRotation)
    {
      run_speed = 1;
      animator.SetFloat("move", 0.3f);
      RotationManager();
    }
    else
    {
      if (animator.GetFloat("move") > 0f)
        animator.SetFloat("move", 0f);
    }
  }

  void DesiredMoveDirection()
  {
    var forward = cam.transform.forward;
    var right = cam.transform.right;
    forward.y = 0;
    right.y = 0;
    forward.Normalize();
    right.Normalize();

    desiredMoveDirection = forward * InputZ + right * InputX;
  }

  void RotationManager()
  {
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
  }

  void MovementManager()
  {
    if (characterController.isGrounded) Gravity = 0;

    if (characterController.isGrounded && playerVelocity.y < 0)
    {
      playerVelocity.y = 0f;
    }

    Gravity -= 9.8f * Time.deltaTime;
    Gravity *= gravityMultiplyer;

    var verticalVelocity = 0.0f;

    if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
    {
      //Gravity = jumpHeight * Time.deltaTime;
      Debug.Log("Jumped");
      playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
      animator.SetTrigger("jump");
    }

    if (characterController.isGrounded && Input.GetKey(KeyCode.Q))
    {
      animator.SetBool("spin", true);
      movementSpeed = 30;
    }
    else
    {
      animator.SetBool("spin", false);
      movementSpeed = 10;
    }

    Vector3 moveDirection = desiredMoveDirection * movementSpeed * run_speed * Time.deltaTime;
    moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
    characterController.Move(moveDirection);

    playerVelocity.y += gravityValue * Time.deltaTime;
    characterController.Move(playerVelocity * Time.deltaTime);

  }
}