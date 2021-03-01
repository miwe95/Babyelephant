using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.MeshOperations;
using Random = UnityEngine.Random;

public class anticoronabean : MonoBehaviour
{
  public NavMeshAgent Agent;

  public LayerMask whatIsGround;

  public Vector3 walkPoint;
  bool walkPointSet;
  public float walkPointRange;

  private float chaseTimer = 20f;
  private float chaseCooldown = 20f;
  private Game game;
  private float conversionTimer = 0f;

  private GameObject closestEnemy;
  private bool inConversion = false;
  public AudioSource coronaLie;

  void Start()
  {
    game = GameObject.Find("Benjamin Blümchen").GetComponent<Game>();
  }

  private GameObject FindClosestEnemy()
  {
    GameObject[] gos;
    gos = GameObject.FindGameObjectsWithTag("Commoner");
    GameObject closest = null;
    float distance = Mathf.Infinity;
    Vector3 position = transform.position;
    foreach (GameObject go in gos)
    {
      Vector3 diff = go.transform.position - position;
      float curDistance = diff.sqrMagnitude;
      if (curDistance < distance)
      {
        closest = go;
        distance = curDistance;
      }
    }
    return closest;
  }

  void Update()
  {
    if (!inConversion)
    {
      if (Agent.isActiveAndEnabled)
      {
        Patroling();
      }
      if (chaseTimer >= chaseCooldown)
      {
        if ((closestEnemy = FindClosestEnemy()) != null)
        {
          transform.LookAt(closestEnemy.transform.position);
          transform.Rotate(new Vector3(0, -90, 0), Space.Self);

          if (Vector3.Distance(transform.position, closestEnemy.transform.position) > 1f)
          {
            transform.Translate(new Vector3(20f * Time.deltaTime, 0, 0));
          }
        }


      }

      chaseTimer += Time.deltaTime;

    }
    else
    {
      conversionTimer += Time.deltaTime;
      if (conversionTimer >= 5f)
      {
        //coronaLie.Play();
        inConversion = false;
        chaseTimer = 0;
        conversionTimer = 0f;
      }
    }

  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.name == "worldcollider")
    {
      game.point_counter += 1; game.corona_bean_counter--;
      Destroy(gameObject);
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Commoner"))
    {
      inConversion = true;
    }
    if (other.gameObject.CompareTag("Player"))
    {
      inConversion = false;
      chaseTimer = 0;
      //Destroy(gameObject);
    }


  }

  private void OnCollisionExit(Collision other)
  {
    if (other.gameObject.CompareTag("Commoner"))
    {
      inConversion = false;
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
      if (Agent.isActiveAndEnabled)
      {
        Agent.SetDestination(walkPoint);
      }
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
