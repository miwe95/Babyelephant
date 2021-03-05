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
  public ParticleSystem ps;
  public GameObject gas_station;
  public AudioSource explosion;
  // Start is called before the first frame update
  void Start()
  {
    col = GetComponent<MeshCollider>();
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.y >= 70f)
    {
      rb.useGravity = true;
      Debug.Log("Gravity activated for: " + gameObject.name);
    }

  }

  void deleteGasStation()
  {
    Destroy(gameObject);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Benjamin Blümchen" && gameObject.name == "Gas_station_A")
    {
      ps.Play();
      explosion.Play();
      rb.useGravity = true;
      //Debug.Log("crashed");
      Vector3 pos = other.gameObject.transform.up;
      rb.AddForce(pos * thrust * 10, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Space.Self);
      Invoke("deleteGasStation", 5);
    }
    else if (other.gameObject.name == "Benjamin Blümchen")
    {
      rb.useGravity = true;
      //Debug.Log("crashed");
      Vector3 pos = other.gameObject.transform.forward;
      rb.AddForce(pos * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Space.Self);
    }
  }

  void OnCollisionEnter(Collision other)
  {
    //Debug.Log("crashed");
    if (other.gameObject.name == "Benjamin Blümchen" && gameObject.name == "Gas_station_A")
    {
      rb.useGravity = true;
      //Debug.Log("crashed");
      Vector3 pos = other.gameObject.transform.up;
      rb.AddForce(pos * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), Space.Self);
    }
    else if (other.gameObject.name == "Benjamin Blümchen")
    {
      rb.useGravity = true;
      // Debug.Log("crashed");
      Vector3 pos = other.gameObject.transform.forward;
      rb.AddForce(pos * thrust, ForceMode.Impulse);
      rb.transform.Rotate(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Space.Self);
    }
  }
}