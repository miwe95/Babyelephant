using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
  public float speed_ = 5.0f;
  public float jump_height_ = 5.0f;

  public bool is_grounded_ = false;
  Animator animator_;
  public Transform Rig;
  public Rigidbody rb;

  void Start()
  {
    //This gets the Animator, which should be attached to the GameObject you are intending to animate.
    animator_ = gameObject.GetComponent<Animator>();
    // The GameObject cannot jump

  }
  void Update()
  {
    playerMovement();
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Ground")
    {
      is_grounded_ = true;
      animator_.SetBool("is_jumping", false);
    }
  }
  void OnCollisionExit(Collision other)
  {
    if (other.gameObject.tag == "Ground")
    {
      is_grounded_ = false;
    }
  }

  void run(float hor, float ver)
  {

    if (Input.GetKeyDown(KeyCode.Space) && is_grounded_)
    {
      Debug.Log("Jump");
      animator_.SetBool("is_jumping", true);
      animator_.SetBool("is_walking", false);
      animator_.SetBool("is_running", false);
      rb.velocity = new Vector3(0, jump_height_ * Time.deltaTime, 0);
      is_grounded_ = false;
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
    {
      Vector3 playerMovement = new Vector3(0f, 0f, 1f) * speed_ * Time.deltaTime;
      transform.Translate(playerMovement, Space.Self);
    }
    else
    {
      Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed_ * Time.deltaTime;
      transform.Translate(playerMovement, Space.Self);
    }
  }

  void playerMovement()
  {

    float hor = Input.GetAxis("Horizontal");
    float ver = Input.GetAxis("Vertical");

    if (Input.GetKey(KeyCode.LeftShift))
    {
      speed_ = 20.0f;

      run(hor, ver);

      if ((hor != 0 || ver != 0) && is_grounded_)
        animator_.SetBool("is_running", true);
      else
        animator_.SetBool("is_running", false);
    }
    else
    {
      animator_.SetBool("is_running", false);
      speed_ = 5.0f;

      run(hor, ver);

      if ((hor != 0 || ver != 0) && is_grounded_)
        animator_.SetBool("is_walking", true);
      else
        animator_.SetBool("is_walking", false);
    }
    //transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
  }
}