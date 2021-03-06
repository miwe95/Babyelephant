﻿using System;
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
  [SerializeField] float jumpHeight = 1f;
  [SerializeField] float run_speed = 1f;
  private Vector3 moveDirection;
  private float gravityValue = -30.81f;
  private Vector3 playerVelocity;
  public bool super_jump;
  public bool rage_mode;
  public Transform transformBenjamin;
  public Material m;
  GameObject elephant_material;
  public AudioSource rageSound;
  public AudioSource superJump;
  public AudioSource blob;

  public GameObject bulletPrefab;
  public Transform bulletSpawnpoint;
  GameObject clone;

  // Start is called before the first frame update
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    cam = Camera.main;
    super_jump = false;
    rage_mode = false;
    animator = GetComponent<Animator>();
    elephant_material = GameObject.Find("Elephant");
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

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.name == "worldcollider")
    {
      transformBenjamin.position = new Vector3(0, 0, 0);
    }
  }

  void InputDecider()
  {
    Speed = new Vector2(InputX, InputZ).sqrMagnitude;

    if (Input.GetKey(KeyCode.LeftShift) && Speed > allowRotation)
    {
      if (!rage_mode)
      {
        run_speed = 2;
        animator.SetFloat("move", 1f);
        RotationManager();
      }
      else
      {
        run_speed = 2;
        animator.SetFloat("move", 3f);
        RotationManager();
      }

    }
    else if (rage_mode)
    {
      run_speed = 2;
      animator.SetFloat("move", 2f);
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

    if (Input.GetKeyDown(KeyCode.E))
    {
      blob.Play();
      GameObject bullet = Instantiate(bulletPrefab, bulletSpawnpoint.position, Quaternion.identity) as GameObject;
      Rigidbody bulletRB = bullet.GetComponentInChildren<Rigidbody>();
      Debug.Log(bulletRB);
      bulletRB.AddForce(transform.forward * 500, ForceMode.Impulse);
      Destroy(bullet, 5);

    }

    if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
    {
      if (super_jump)
      {
        superJump.Play();
        playerVelocity.y += Mathf.Sqrt(10 * -3.0f * gravityValue);
        super_jump = false;
        m = elephant_material.GetComponent<SkinnedMeshRenderer>().material;
        m.color = new Color(102f / 255f, 102f / 255f, 102f / 255f);
      }
      else
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
      Debug.Log("Jumped");
      animator.SetTrigger("jump");
    }

    if (characterController.isGrounded && Input.GetKey(KeyCode.Q))
    {
      animator.SetBool("spin", true);
      movementSpeed = 10;
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
