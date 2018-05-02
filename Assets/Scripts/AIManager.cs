using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class AIManager : MonoBehaviour
{

    NavMeshAgent nm;
    //Vector3 desiredVelocity;
    public List<Transform> waypoints;
    TankHealth tank;
    //public Transform target;

    int counter;

    private void Awake()
    {
        nm = GetComponent<NavMeshAgent>();
        counter = 0;
        tank = GetComponent<TankHealth>();
        //setDestination();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            counter++;
            
            setDestination();
        }
       
    }

    public void setDestination()
    {
        Vector3 targetVector = waypoints[counter].transform.position;
        //Debug.Log("DirectionChange");
        nm.SetDestination(targetVector);
    }

    private void Update()
    {
        if(tank.isDead == true)
        {
            counter = 0;
            tank.isDead = false;
            setDestination();
        }
    }

}
