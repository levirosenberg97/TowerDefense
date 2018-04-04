using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public Transform spawnPoint;
    AIManager enemyAI;

    public List<Transform> waypoints;


	void Start ()
    {
        enemyAI = enemy.GetComponent<AIManager>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
    void Spawn()
    {
        
        for(int i = 0; i < waypoints.Count; i++)
        {
            enemyAI.waypoints[i] = waypoints[i]; 
        }
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
