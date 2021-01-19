using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class infection : MonoBehaviour
{
  public NavMeshAgent Agent;

  public LayerMask whatIsGround;

  public Vector3 walkPoint;
  bool walkPointSet;
  public float walkPointRange;

  public bool hasCorona;
  public float infectionChance;
  float infectionRange = 5;
  bool personInRange;
  float infectionRate;

  public GameObject sick_bean;

  // Start is called before the first frame update


  // Update is called once per frame
  void Update()
  {
    Patroling();

    if (hasCorona)
    {

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

  public bool getCoronaStatus()
  {
    return hasCorona;
  }

  void OnCollisionEnter(Collision hitInfo)
  {
    Debug.Log("J");
    if (hitInfo.collider.GetComponent<infection>().getCoronaStatus())
    {

      if (Random.value > infectionRate)
      {
        hasCorona = true;
        Instantiate(sick_bean, transform.position, Quaternion.identity);
        Destroy(gameObject);
      }
    }

  }

}
