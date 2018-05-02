using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class MineTurretScript : MonoBehaviour
{
    ObjectPool pool;
    public float bulletSpeed;
    public string objectTag;

    public int damage;
    public float timeBetweenShots;

    float timer;

    public int value;

	void Start ()
    {
        pool = GetComponent<ObjectPool>();
	}
	
    public void Fire()
    {
        GameObject northBullet = pool.GetObject();
        northBullet.transform.position = transform.position;

        northBullet.transform.parent = null;
        northBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;


        GameObject southBullet = pool.GetObject();
        southBullet.transform.position = transform.position;

        southBullet.transform.parent = null;
        southBullet.GetComponent<Rigidbody>().velocity = -transform.forward * bulletSpeed;


        GameObject eastBullet = pool.GetObject();
        eastBullet.transform.position = transform.position;

        eastBullet.transform.parent = null;
        eastBullet.GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;


        GameObject westBullet = pool.GetObject();
        westBullet.transform.position = transform.position;

        westBullet.transform.parent = null;
        westBullet.GetComponent<Rigidbody>().velocity = -transform.right * bulletSpeed;

        northBullet.SetActive(true);
        southBullet.SetActive(true);
        eastBullet.SetActive(true);
        westBullet.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == objectTag && timer >= timeBetweenShots)
        {
            Fire();
            timer = 0;
        }
    }


    private void Update()
    {
        timer += Time.deltaTime;
    }
}
