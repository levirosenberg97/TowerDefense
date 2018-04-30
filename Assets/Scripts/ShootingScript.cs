using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    ObjectPool pool;
    public float bulletSpeed;

	// Use this for initialization
	void Start ()
    {
        pool = GetComponent<ObjectPool>();
	}
	
    public void Fire()
    {
        GameObject spawnedBullet = pool.GetObject();
        spawnedBullet.transform.position = transform.position;

        spawnedBullet.transform.rotation = transform.rotation;

        spawnedBullet.transform.parent = null;
        spawnedBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        spawnedBullet.SetActive(true);
    }
}
