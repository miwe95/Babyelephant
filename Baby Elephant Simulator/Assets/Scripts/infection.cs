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

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Patroling();
    }

    void Patroling()
    {
        if(!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            Agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
}
