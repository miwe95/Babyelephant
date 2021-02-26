using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class commoner : MonoBehaviour
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
  private float conversionTimer = 0f;
  public GameObject Enemy;

  public bool inConversion = false;
  public GameObject player;
  private Game game;

  void Start()
  {

    assemblyObject = GameObject.FindGameObjectWithTag("Assembly");
    assemblepoint = assemblyObject.GetComponent<Transform>();

    assembyCooldown = Random.Range(80, 160);
    patrolingCooldown = Random.Range(80, 160);
    game = GameObject.Find("Benjamin Blümchen").GetComponent<Game>();
  }

  void Update()
  {

    if (!inConversion)
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
        //if (transform.position.z <= 0 )
        Patroling();

        patrolingCooldown = Random.Range(80, 160);
      }
    }
    else
    {
      conversionTimer += Time.deltaTime;
      if (conversionTimer >= 5f)
      {
        Instantiate(Enemy, transform.position, Quaternion.identity);
        game.corona_bean_counter++;
        Destroy(gameObject);
      }
    }

  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.name == "worldcollider")
    {
      Destroy(gameObject);
      game.point_counter -= 1;

    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      inConversion = true;
    }


  }

  private void OnCollisionExit(Collision other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      inConversion = false;
    }


  }

  void Patroling()
  {
    Debug.Log("patorlin");
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
