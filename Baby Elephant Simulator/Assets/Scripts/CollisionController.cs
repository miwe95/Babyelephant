using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class CollisionController : MonoBehaviour
{
  private CapsuleCollider col;
  private Rigidbody rb;
  public float thrust = 1f;
  private NavMeshAgent myAgent;

  private float physicsTimer = 0f;
  private float physicsCooldown = 5f;
  private bool collisionExit;

  // Start is called before the first frame update
  void Start()
  {
    col = GetComponent<CapsuleCollider>();
    rb = GetComponent<Rigidbody>();
    myAgent = GetComponent<NavMeshAgent>();

  }

  // Update is called once per frame
  void Update()
  {
    if (collisionExit)
    {
      if (physicsTimer >= physicsCooldown)
      {
        physicsTimer = 0;
        myAgent.enabled = true;
        collisionExit = false;
      }
      physicsTimer += Time.deltaTime;
    }

  }

  private void OnTriggerExit(Collider other)
  {
    collisionExit = true;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      myAgent.enabled = false;
      //Debug.Log("crashed");
      rb.AddForce(new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)) * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Space.Self);
    }
    myAgent.velocity = rb.velocity;
  }

  void FixedUpdate()
  {

  }

}
