using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Commoner : MonoBehaviour
{
  public NavMeshAgent Agent;

  public LayerMask whatIsGround;

  public Vector3 walkPoint;
  bool walkPointSet;
  public float walkPointRange;

  public Transform assemblepoint;
  private GameObject assemblyObject;
  private float speed = 5f;

  private float assemblyTimer = 0f;
  private float assembyCooldown = 20f;
  private float patrolingCooldown = 20f;

  void Start()
  {

    assemblyObject = GameObject.FindGameObjectWithTag("Assembly");
    assemblepoint = assemblyObject.GetComponent<Transform>();

    assembyCooldown = Random.Range(80, 160);
    patrolingCooldown = Random.Range(80, 160);


  }

  void Update()
  {

    if (assemblyTimer >= assembyCooldown)
    {
      patrolingCooldown -= Time.deltaTime;
      transform.LookAt(assemblepoint.position);
      transform.Rotate(new Vector3(0, -90, 0), Space.Self);

      if (Vector3.Distance(transform.position, assemblepoint.position) > 1f)
      {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
      }
      if (patrolingCooldown <= 0)
      {
        assemblyTimer = 0;
      }
    }
    else
    {
      Patroling();
      assemblyTimer += Time.deltaTime;
      patrolingCooldown = Random.Range(80, 160);
    }


  }

  void Patroling()
  {
    if (!walkPointSet)
    {
      SearchWalkPoint();
    }
    else
    {
      Agent.SetDestination(walkPoint);
    }

    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    if (distanceToWalkPoint.magnitude < 1f)
    {
      walkPointSet = false;
    }
  }

  void SearchWalkPoint()
  {

    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    float randomX = Random.Range(-walkPointRange, walkPointRange);

    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    {
      walkPointSet = true;
    }
  }
}
