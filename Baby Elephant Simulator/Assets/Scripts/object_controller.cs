using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class object_controller : MonoBehaviour
{
  private MeshCollider col;
  private Rigidbody rb;
  public float thrust = 1f;

  // Start is called before the first frame update
  void Start()
  {
    col = GetComponent<MeshCollider>();
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      rb.useGravity = true;
      //Debug.Log("crashed");
      rb.AddForce(new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)) * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Space.Self);
    }
  }

  void OnCollisionEnter(Collision other)
  {
    //Debug.Log("crashed");
    if (other.gameObject.tag == "Player")
    {
      rb.useGravity = true;
      // Debug.Log("crashed");
      rb.AddForce(new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)) * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Space.Self);
    }
  }
}