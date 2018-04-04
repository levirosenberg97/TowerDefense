using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{

    NavMeshAgent nm;
    Vector3 desiredVelocity;
    public List<Transform> waypoints;

    //public Transform target;

    int counter;

    private void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        counter = 0;
        setDestination();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            counter++;
            Debug.Log("Hit");
            setDestination();
        }
    }

    private void setDestination()
    {
        Vector3 targetVector = waypoints[counter].transform.position;
        Debug.Log("DirectionChange");
        nm.SetDestination(targetVector);
    }
    
}
