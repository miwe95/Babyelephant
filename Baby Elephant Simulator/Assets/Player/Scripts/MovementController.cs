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

    private Vector3 desiredMoveDirection;
    
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float allowRotation = 0.1f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float gravityMultiplyer = 0.5f;
    [SerializeField] float jumpHeight = 2f;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
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

        if (Speed > allowRotation)
        {
            RotationManager();
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
        Gravity -= 9.8f * Time.deltaTime;
        Gravity *= gravityMultiplyer;

        var verticalVelocity = 0.0f;

        if (characterController.isGrounded && Input.GetButton("Jump")) {
            // Gravity = jumpHeight * Time.deltaTime;
            verticalVelocity = jumpHeight;
        }

        Vector3 jumpVector = new Vector3(0, verticalVelocity, 0);
        characterController.Move(jumpVector * Time.deltaTime);

        Vector3 moveDirection = desiredMoveDirection * movementSpeed * Time.deltaTime;
        moveDirection = new Vector3(moveDirection.x, Gravity, moveDirection.z);
        characterController.Move(moveDirection);

    }
}