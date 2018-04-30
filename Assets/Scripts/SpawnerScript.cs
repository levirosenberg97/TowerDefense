using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //public GameObject enemy;
    public float spawnTime;

    AIManager enemyAI;
    TankHealth enemyHealth;

    public int amountSpawned;

    public List<Transform> waypoints;
    public MoneyTracker moneyTracker;

    ObjectPool pool;

    public WaveManager wave;

	void Start ()
    {
        pool = GetComponent<ObjectPool>();
        
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0 && amountSpawned < wave.enemiesSpawned)
        {
            Spawn();
            spawnTime = wave.spawnTime;
            amountSpawned++;
        }

        if(wave.timer < 1)
        {
            amountSpawned = 0;
        }
    }

    void Spawn()
    {
        GameObject spawnedEnemy = pool.GetObject();

        enemyAI = spawnedEnemy.GetComponent<AIManager>();

        enemyHealth = spawnedEnemy.GetComponent<TankHealth>();

        for (int i = 0; i < waypoints.Count; i++)
        {
            enemyAI.waypoints[i] = waypoints[i]; 
        }

        enemyHealth.health = wave.tankHealth;

        enemyHealth.moneyTracker = moneyTracker;

        spawnedEnemy.transform.position = transform.position;

        spawnedEnemy.transform.rotation = transform.rotation;

        spawnedEnemy.SetActive(true);
      
        enemyAI.setDestination();
        
    }

}
