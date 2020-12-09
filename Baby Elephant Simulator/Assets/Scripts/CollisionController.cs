using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CollisionController : MonoBehaviour
{
  private CapsuleCollider col;
  private Rigidbody rb;
  public float thrust = 1f;
  private NavMeshAgent myAgent;

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

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("crashed");
      rb.AddForce(new Vector3(0, Random.Range(1, 100), 0) * thrust, ForceMode.Impulse);
    }
    myAgent.velocity = rb.velocity;
  }

  void FixedUpdate()
  {

  }

}
