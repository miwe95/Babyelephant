using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
  private CapsuleCollider col;
  private Rigidbody rb;
  public float thrust = 1f;
  // Start is called before the first frame update
  void Start()
  {
    col = GetComponent<CapsuleCollider>();
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
      rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    }
  }

  void FixedUpdate()
  {

  }

}
